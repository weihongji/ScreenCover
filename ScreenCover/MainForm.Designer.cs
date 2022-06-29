
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
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenu
			// 
			this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemMin,
            this.menuItemExit});
			this.contextMenu.Name = "contextMenu";
			this.contextMenu.Size = new System.Drawing.Size(181, 70);
			// 
			// menuItemMin
			// 
			this.menuItemMin.Name = "menuItemMin";
			this.menuItemMin.Size = new System.Drawing.Size(180, 22);
			this.menuItemMin.Text = "&Minimize";
			this.menuItemMin.Click += new System.EventHandler(this.menuItemMin_Click);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new System.Drawing.Size(180, 22);
			this.menuItemExit.Text = "E&xit";
			this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.ContextMenuStrip = this.contextMenu;
			this.Name = "MainForm";
			this.Opacity = 0.5D;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Screen Cover";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseDown);
			this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseMove);
			this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseUp);
			this.Move += new System.EventHandler(this.MainForm_Move);
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip contextMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.ToolStripMenuItem menuItemMin;
	}
}

