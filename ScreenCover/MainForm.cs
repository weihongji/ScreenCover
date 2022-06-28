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

		public MainForm(string[] args) {
			InitializeComponent();
			this.args = args;
		}

		private void MainForm_Load(object sender, EventArgs e) {
			applyArguments(args);
		}

		private void applyArguments(string[] args) {
			int x = GetConfigInt("left", int.MinValue);
			int y = GetConfigInt("top", int.MinValue);
			int w = GetConfigInt("width", int.MinValue);
			int h = GetConfigInt("height", int.MinValue);
			int bottom = GetConfigInt("bottom", int.MinValue);
			int right = GetConfigInt("right", int.MinValue);
			double o = GetConfigDouble("opacity", -1);

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

		private void MainForm_Resize(object sender, EventArgs e) {
			showSize();
		}

		private void MainForm_Move(object sender, EventArgs e) {
			showSize();
		}

		private void showSize() {
			this.Text = String.Format("Screen Cover (Size: {0} x {1}, [{2}, {3}])", this.Width, this.Height, this.Left, this.Top);
		}
	}
}
