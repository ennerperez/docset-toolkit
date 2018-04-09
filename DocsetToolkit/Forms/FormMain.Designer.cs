namespace Toolkit.Forms
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
        	this.toolStripMenu = new System.Windows.Forms.ToolStrip();
        	this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButtonFile = new System.Windows.Forms.ToolStripDropDownButton();
        	this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
        	this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.sourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolStripButtonDocsets = new System.Windows.Forms.ToolStripDropDownButton();
        	this.toolStripButtonUpdates = new System.Windows.Forms.ToolStripButton();
        	this.toolTipMain = new System.Windows.Forms.ToolTip(this.components);
        	this.saveFileDialogMain = new System.Windows.Forms.SaveFileDialog();
        	this.openFileDialogMain = new System.Windows.Forms.OpenFileDialog();
        	this.helpProviderMain = new System.Windows.Forms.HelpProvider();
        	this.toolStripMenu.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// toolStripMenu
        	// 
        	this.toolStripMenu.AutoSize = false;
        	this.toolStripMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
        	this.toolStripMenu.CanOverflow = false;
        	this.toolStripMenu.Dock = System.Windows.Forms.DockStyle.Left;
        	this.toolStripMenu.GripMargin = new System.Windows.Forms.Padding(0);
        	this.toolStripMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
        	this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripButtonClose,
			this.toolStripButtonAbout,
			this.toolStripButtonFile,
			this.toolStripSeparator8,
			this.toolStripButtonDocsets,
			this.toolStripButtonUpdates});
        	this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
        	this.toolStripMenu.Name = "toolStripMenu";
        	this.toolStripMenu.Padding = new System.Windows.Forms.Padding(0);
        	this.toolStripMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        	this.toolStripMenu.Size = new System.Drawing.Size(48, 441);
        	this.toolStripMenu.TabIndex = 11;
        	// 
        	// toolStripButtonClose
        	// 
        	this.toolStripButtonClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.toolStripButtonClose.AutoSize = false;
        	this.toolStripButtonClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
        	this.toolStripButtonClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        	this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonClose.Margin = new System.Windows.Forms.Padding(0);
        	this.toolStripButtonClose.Name = "toolStripButtonClose";
        	this.toolStripButtonClose.Size = new System.Drawing.Size(48, 48);
        	this.toolStripButtonClose.Text = "&Close";
        	this.toolStripButtonClose.Click += new System.EventHandler(this.ToolStripButtonExit_Click);
        	// 
        	// toolStripButtonAbout
        	// 
        	this.toolStripButtonAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.toolStripButtonAbout.AutoSize = false;
        	this.toolStripButtonAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
        	this.toolStripButtonAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        	this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonAbout.Margin = new System.Windows.Forms.Padding(0);
        	this.toolStripButtonAbout.Name = "toolStripButtonAbout";
        	this.toolStripButtonAbout.Size = new System.Drawing.Size(48, 48);
        	this.toolStripButtonAbout.Text = "&About...";
        	this.toolStripButtonAbout.Click += new System.EventHandler(this.ToolStripButtonAbout_Click);
        	// 
        	// toolStripButtonFile
        	// 
        	this.toolStripButtonFile.AutoSize = false;
        	this.toolStripButtonFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButtonFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.createToolStripMenuItem,
			this.toolStripSeparator3,
			this.printToolStripMenuItem,
			this.toolStripSeparator1,
			this.importToolStripMenuItem,
			this.exportToolStripMenuItem,
			this.toolStripSeparator2,
			this.sourceToolStripMenuItem,
			this.exploreToolStripMenuItem});
        	this.toolStripButtonFile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonFile.Image")));
        	this.toolStripButtonFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        	this.toolStripButtonFile.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonFile.Margin = new System.Windows.Forms.Padding(0);
        	this.toolStripButtonFile.Name = "toolStripButtonFile";
        	this.toolStripButtonFile.ShowDropDownArrow = false;
        	this.toolStripButtonFile.Size = new System.Drawing.Size(48, 48);
        	this.toolStripButtonFile.Text = "&File";
        	// 
        	// createToolStripMenuItem
        	// 
        	this.createToolStripMenuItem.Enabled = false;
        	this.createToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        	this.createToolStripMenuItem.Name = "createToolStripMenuItem";
        	this.createToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
        	this.createToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
        	this.createToolStripMenuItem.Text = "&Create...";
        	this.createToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// toolStripSeparator3
        	// 
        	this.toolStripSeparator3.Name = "toolStripSeparator3";
        	this.toolStripSeparator3.Size = new System.Drawing.Size(157, 6);
        	// 
        	// printToolStripMenuItem
        	// 
        	this.printToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        	this.printToolStripMenuItem.Name = "printToolStripMenuItem";
        	this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
        	this.printToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
        	this.printToolStripMenuItem.Text = "&Print...";
        	this.printToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
        	// 
        	// importToolStripMenuItem
        	// 
        	this.importToolStripMenuItem.Enabled = false;
        	this.importToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        	this.importToolStripMenuItem.Name = "importToolStripMenuItem";
        	this.importToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
        	this.importToolStripMenuItem.Text = "&Import...";
        	this.importToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// exportToolStripMenuItem
        	// 
        	this.exportToolStripMenuItem.Enabled = false;
        	this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
        	this.exportToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
        	this.exportToolStripMenuItem.Text = "&Export...";
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(157, 6);
        	// 
        	// sourceToolStripMenuItem
        	// 
        	this.sourceToolStripMenuItem.Name = "sourceToolStripMenuItem";
        	this.sourceToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
        	this.sourceToolStripMenuItem.Text = "&Source";
        	// 
        	// exploreToolStripMenuItem
        	// 
        	this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
        	this.exploreToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
        	this.exploreToolStripMenuItem.Text = "E&xplore";
        	// 
        	// toolStripSeparator8
        	// 
        	this.toolStripSeparator8.Name = "toolStripSeparator8";
        	this.toolStripSeparator8.Size = new System.Drawing.Size(47, 6);
        	// 
        	// toolStripButtonDocsets
        	// 
        	this.toolStripButtonDocsets.AutoSize = false;
        	this.toolStripButtonDocsets.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButtonDocsets.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDocsets.Image")));
        	this.toolStripButtonDocsets.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        	this.toolStripButtonDocsets.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonDocsets.Margin = new System.Windows.Forms.Padding(0);
        	this.toolStripButtonDocsets.Name = "toolStripButtonDocsets";
        	this.toolStripButtonDocsets.ShowDropDownArrow = false;
        	this.toolStripButtonDocsets.Size = new System.Drawing.Size(48, 48);
        	this.toolStripButtonDocsets.Text = "&Docsets";
        	// 
        	// toolStripButtonUpdates
        	// 
        	this.toolStripButtonUpdates.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.toolStripButtonUpdates.AutoSize = false;
        	this.toolStripButtonUpdates.Checked = true;
        	this.toolStripButtonUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.toolStripButtonUpdates.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.toolStripButtonUpdates.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonUpdates.Image")));
        	this.toolStripButtonUpdates.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
        	this.toolStripButtonUpdates.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButtonUpdates.Margin = new System.Windows.Forms.Padding(0);
        	this.toolStripButtonUpdates.Name = "toolStripButtonUpdates";
        	this.toolStripButtonUpdates.Size = new System.Drawing.Size(48, 48);
        	this.toolStripButtonUpdates.Text = "&Updates";
        	this.toolStripButtonUpdates.Click += new System.EventHandler(this.ToolStripButtonUpdates_Click);
        	// 
        	// saveFileDialogMain
        	// 
        	this.saveFileDialogMain.DefaultExt = "jpg";
        	this.saveFileDialogMain.Filter = "Valid files|*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.gif;*.txt;*.bin;*.b64|Image f" +
	"iles|*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.gif|Text files|*.txt;*.bin;*.b64|Al" +
	"l files|*.*";
        	this.saveFileDialogMain.Tag = "";
        	this.saveFileDialogMain.Title = "Save...";
        	// 
        	// openFileDialogMain
        	// 
        	this.openFileDialogMain.DefaultExt = "jpg";
        	this.openFileDialogMain.Filter = "Valid files|*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.gif;*.txt;*.bin;*.b64|Image f" +
	"iles|*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.gif|Text files|*.txt;*.bin;*.b64|Al" +
	"l files|*.*";
        	this.openFileDialogMain.Tag = "";
        	this.openFileDialogMain.Title = "Open...";
        	// 
        	// FormMain
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.SystemColors.Window;
        	this.ClientSize = new System.Drawing.Size(624, 441);
        	this.Controls.Add(this.toolStripMenu);
        	this.MinimumSize = new System.Drawing.Size(640, 480);
        	this.Name = "FormMain";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Docset Toolkit";
        	this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        	this.Load += new System.EventHandler(this.FormMain_Load);
        	this.Shown += new System.EventHandler(this.FormMain_Shown);
        	this.toolStripMenu.ResumeLayout(false);
        	this.toolStripMenu.PerformLayout();
        	this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonFile;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripDropDownButton toolStripButtonDocsets;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem sourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdates;
        private System.Windows.Forms.ToolTip toolTipMain;
        private System.Windows.Forms.SaveFileDialog saveFileDialogMain;
        private System.Windows.Forms.OpenFileDialog openFileDialogMain;
        private System.Windows.Forms.HelpProvider helpProviderMain;
    }
}

