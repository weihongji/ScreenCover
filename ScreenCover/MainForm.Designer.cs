
namespace ScreenCover
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.menuItemMin = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemMax = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemNormal = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.lblContent = new System.Windows.Forms.Label();
			this.lblOpacity = new System.Windows.Forms.Label();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMin,
            this.menuItemMax,
            this.menuItemNormal,
            this.menuItemAbout,
            this.menuItemExit});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(203, 114);
			// 
			// menuItemMin
			// 
			this.menuItemMin.Name = "menuItemMin";
			this.menuItemMin.Size = new System.Drawing.Size(202, 22);
			this.menuItemMin.Text = "Mi&nimize (Esc)";
			this.menuItemMin.Click += new System.EventHandler(this.menuItemMin_Click);
			// 
			// menuItemMax
			// 
			this.menuItemMax.Name = "menuItemMax";
			this.menuItemMax.Size = new System.Drawing.Size(202, 22);
			this.menuItemMax.Text = "&Maximize (Ctrl+Enter)";
			this.menuItemMax.Click += new System.EventHandler(this.menuItemMax_Click);
			// 
			// menuItemNormal
			// 
			this.menuItemNormal.Name = "menuItemNormal";
			this.menuItemNormal.Size = new System.Drawing.Size(202, 22);
			this.menuItemNormal.Text = "N&ormal (Ctrl+Enter)";
			this.menuItemNormal.Visible = false;
			this.menuItemNormal.Click += new System.EventHandler(this.menuItemNormal_Click);
			// 
			// menuItemAbout
			// 
			this.menuItemAbout.Name = "menuItemAbout";
			this.menuItemAbout.Size = new System.Drawing.Size(202, 22);
			this.menuItemAbout.Text = "&About";
			this.menuItemAbout.Click += new System.EventHandler(this.menuItemAbout_Click);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new System.Drawing.Size(202, 22);
			this.menuItemExit.Text = "E&xit (Alt+X)";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// lblContent
			// 
			this.lblContent.AutoSize = true;
			this.lblContent.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblContent.Location = new System.Drawing.Point(0, 0);
			this.lblContent.Name = "lblContent";
			this.lblContent.Size = new System.Drawing.Size(146, 17);
			this.lblContent.TabIndex = 1;
			this.lblContent.Text = "(left, top) width x height";
			// 
			// lblOpacity
			// 
			this.lblOpacity.AutoSize = true;
			this.lblOpacity.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.lblOpacity.Location = new System.Drawing.Point(169, 106);
			this.lblOpacity.Name = "lblOpacity";
			this.lblOpacity.Size = new System.Drawing.Size(87, 23);
			this.lblOpacity.TabIndex = 2;
			this.lblOpacity.Text = "Opacity";
			this.lblOpacity.Visible = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.ContextMenuStrip = this.contextMenu;
			this.ControlBox = false;
			this.Controls.Add(this.lblOpacity);
			this.Controls.Add(this.lblContent);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MainForm";
			this.Opacity = 0.5D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.TopMost = true;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.DoubleClick += new System.EventHandler(this.MainForm_DoubleClick);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
			this.Move += new System.EventHandler(this.MainForm_Move);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.ToolStripMenuItem menuItemMin;
		private System.Windows.Forms.ToolStripMenuItem menuItemMax;
		private System.Windows.Forms.ToolStripMenuItem menuItemNormal;
		private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
		private System.Windows.Forms.Label lblContent;
		private System.Windows.Forms.Label lblOpacity;
	}
}

