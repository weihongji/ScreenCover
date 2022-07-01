using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenCover
{
	public partial class MainForm : Form
	{
		private string[] args;
		private Point dragStart;
		private int changeStep;

		public MainForm(string[] args) {
			InitializeComponent();
			this.args = args;
		}

		private void MainForm_Load(object sender, EventArgs e) {
			applyArguments(args);
			this.BackColor = Color.White;

			changeStep = GetConfigInt("change-step");
			if (changeStep <= 0) {
				changeStep = 1;
			}
		}

		private void applyArguments(string[] args) {
			int x = GetConfigInt("left", int.MinValue);
			int y = GetConfigInt("top", int.MinValue);
			int w = GetConfigInt("width", int.MinValue);
			int h = GetConfigInt("height", int.MinValue);
			int bottom = GetConfigInt("bottom", int.MinValue);
			int right = GetConfigInt("right", int.MinValue);
			double o = GetConfigDouble("opacity", -1);
			bool showSize = GetConfigBool("show-size");

			if (this.args != null && this.args.Length > 0) {
				for (int i = 0; i < args.Length; i++) {
					String s = args[i];
					int tmp = 0;
					double tmpd = 0.0;
					if (s.StartsWith("left=")) {
						if (int.TryParse(s.Substring("left=".Length), out tmp)) {
							x = tmp;
						}
					}
					else if (s.StartsWith("top=")) {
						if (int.TryParse(s.Substring("top=".Length), out tmp)) {
							y = tmp;
						}
					}
					else if (s.StartsWith("width=")) {
						if (int.TryParse(s.Substring("width=".Length), out tmp)) {
							w = tmp;
						}
					}
					else if (s.StartsWith("height=")) {
						if (int.TryParse(s.Substring("height=".Length), out tmp)) {
							h = tmp;
						}
					}
					else if (s.StartsWith("bottom=")) {
						if (int.TryParse(s.Substring("bottom=".Length), out tmp)) {
							bottom = tmp;
						}
					}
					else if (s.StartsWith("right=")) {
						if (int.TryParse(s.Substring("right=".Length), out tmp)) {
							right = tmp;
						}
					}
					else if (s.StartsWith("opacity=")) {
						if (double.TryParse(s.Substring("opacity=".Length), out tmpd)) {
							o = tmpd;
						}
					}
				}
			}

			if (bottom > int.MinValue) {
				var area = Screen.GetWorkingArea(new Point(0, 0));
				if (y == int.MinValue) {
					if (h == int.MinValue) {
						h = this.Height;
					}
					y = area.Height - bottom - h;
				}
				else if (h == int.MinValue) {
					if (y < area.Height - bottom) {
						h = area.Height - bottom - y;
					}
				}
			}

			if (right > int.MinValue) {
				var area = Screen.GetWorkingArea(new Point(0, 0));
				if (x == int.MinValue) {
					if (w == int.MinValue) {
						w = this.Width;
					}
					x = area.Width - right - w;
				}
				else if (w == int.MinValue) {
					if (x < area.Width - right) {
						w = area.Width - right - x;
					}
				}
			}

			if (x > int.MinValue) {
				this.Left = x;
			}
			if (y > int.MinValue) {
				this.Top = y;
			}
			if (w > int.MinValue) {
				this.Width = w;
			}
			if (h > int.MinValue) {
				this.Height = h;
			}
			if (o >= 0) {
				this.Opacity = o;
			}
			toggleShowSize(showSize);
		}

		private static int GetConfigInt(string key, int defaultValue = 0) {
			var config = System.Configuration.ConfigurationManager.AppSettings[key];
			int i;
			if (!string.IsNullOrEmpty(config) && int.TryParse(config, out i)) {
				return i;
			}
			return defaultValue;
		}

		private static double GetConfigDouble(string key, double defaultValue = 0) {
			var config = System.Configuration.ConfigurationManager.AppSettings[key];
			double tmp;
			if (!string.IsNullOrEmpty(config) && double.TryParse(config, out tmp)) {
				return tmp;
			}
			return defaultValue;
		}

		private static bool GetConfigBool(string key, bool defaultValue = false) {
			var config = System.Configuration.ConfigurationManager.AppSettings[key];
			bool b;
			if (!string.IsNullOrEmpty(config) && bool.TryParse(config, out b)) {
				return b;
			}
			return defaultValue;
		}

		private void MainForm_Resize(object sender, EventArgs e) {
			showSize();
		}

		private void MainForm_Move(object sender, EventArgs e) {
			showSize();
		}

		private void showSize() {
			lblSize.Text = String.Format("({0}, {1}), {2} x {3}", this.Left, this.Top, this.Width, this.Height);

			bool isMax = this.WindowState == FormWindowState.Maximized;
			menuItemMax.Visible = !isMax;
			menuItemNormal.Visible = isMax;

			if (canShowOpacity()) {
				lblOpacity.Left = this.Width / 2;
				lblOpacity.Top = (this.Height - lblOpacity.Height) / 2;
			}
			else {
				hideOpacity();
			}
		}

		private bool canShowOpacity() {
			return this.Height > 50 && this.Width > 400;
		}

		private void MainForm_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Escape) { // ESC
				this.WindowState = FormWindowState.Minimized;
			}
			else if (e.Alt && e.KeyCode == Keys.X) { // ALT + X
				e.Handled = e.SuppressKeyPress = true;
				Application.Exit();
			}
			else if (e.Control && e.KeyCode == Keys.Enter) { // Ctrl + Enter
				if (this.WindowState == FormWindowState.Normal) {
					this.WindowState = FormWindowState.Maximized;
				}
				else if (this.WindowState == FormWindowState.Maximized) {
					this.WindowState = FormWindowState.Normal;
				}
			}
			else if (e.Shift) {
				if (e.KeyCode == Keys.Left) { // SHIFT + Left Arrow
					this.Width += changeStep;
					this.Left -= changeStep;
				}
				else if (e.KeyCode == Keys.Right) { // SHIFT + Right Arrow
					this.Width += changeStep;
				}
				else if (e.KeyCode == Keys.Up) { // SHIFT + Up Arrow
					this.Height += changeStep;
					this.Top -= changeStep;
				}
				else if (e.KeyCode == Keys.Down) { // SHIFT + Down Arrow
					this.Height += changeStep;
				}
			}
			else if (e.Alt) {
				if (e.KeyCode == Keys.Left) { // ALT + Left Arrow
					this.Width -= changeStep;
				}
				else if (e.KeyCode == Keys.Right) { // ALT + Right Arrow
					this.Width -= changeStep;
					this.Left += changeStep;
				}
				else if (e.KeyCode == Keys.Up) { // ALT + Up Arrow
					this.Height -= changeStep;
				}
				else if (e.KeyCode == Keys.Down) { // ALT + Down Arrow
					this.Height -= changeStep;
					this.Top += changeStep;
				}
			}
			else if (e.Control) {
				if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Down) { // ALT + Left/Down
					this.Opacity -= 0.01;
					showOpacity();
				}
				else if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Up) { // ALT + Right/Up
					this.Opacity += 0.01;
					showOpacity();
				}
			}
			else {
				if (e.KeyCode == Keys.Left) { // Left Arrow
					this.Left -= changeStep;
				}
				else if (e.KeyCode == Keys.Right) { // Right Arrow
					this.Left += changeStep;
				}
				else if (e.KeyCode == Keys.Up) { // Up Arrow
					this.Top -= changeStep;
				}
				else if (e.KeyCode == Keys.Down) { // Down Arrow
					this.Top += changeStep;
				}
			}
		}

		private void MainForm_KeyUp(object sender, KeyEventArgs e) {
			if (!e.Control) {
				hideOpacity();
			}
		}

		private void showOpacity() {
			if (!lblOpacity.Visible && canShowOpacity()) {
				lblOpacity.Visible = true;
			}
			lblOpacity.Text = this.Opacity.ToString("0.00");
		}

		private void hideOpacity() {
			if (lblOpacity.Visible) {
				lblOpacity.Visible = false;
			}
		}

		private void MainForm_MouseDown(object sender, MouseEventArgs e) {
			this.dragStart = e.Location;
		}

		private void MainForm_MouseMove(object sender, MouseEventArgs e) {
			if (this.dragStart == Point.Empty) {
				return;
			}
			// https://ezinearticles.com/?Drag-Windows-Form-in-C&id=1013708
			this.Left += e.X - dragStart.X;
			this.Top += e.Y - dragStart.Y;
		}

		private void MainForm_MouseUp(object sender, MouseEventArgs e) {
			this.dragStart = Point.Empty;
		}

		private void menuItemMin_Click(object sender, EventArgs e) {
			this.WindowState = FormWindowState.Minimized;
		}

		private void menuItemMax_Click(object sender, EventArgs e) {
			this.WindowState = FormWindowState.Maximized;
		}

		private void menuItemNormal_Click(object sender, EventArgs e) {
			this.WindowState = FormWindowState.Normal;
		}

		private void menuItemShowSize_Click(object sender, EventArgs e) {
			toggleShowSize(!lblSize.Visible);
		}

		private void toggleShowSize(bool toShow) {
			if (toShow) {
				lblSize.Visible = true;
				menuItemShowSize.Text = "Hide &Size";
			}
			else {
				lblSize.Visible = false;
				menuItemShowSize.Text = "Show &Size";
			}
		}

		private void menuItemAbout_Click(object sender, EventArgs e) {
			var about = new AboutBox();
			this.TopMost = false;
			about.ShowDialog();
			this.TopMost = true;
		}

		private void menuItemExit_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void MainForm_DoubleClick(object sender, EventArgs e) {
			if (this.WindowState == FormWindowState.Maximized) {
				this.WindowState = FormWindowState.Normal;
			}
			else {
				this.WindowState = FormWindowState.Maximized;
			}
		}
	}
}
