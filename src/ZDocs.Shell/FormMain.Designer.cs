namespace ZDocs.Shell
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
            this.listViewContent = new BrightIdeasSoftware.FastDataListView();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStripTab = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.listViewContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.contextMenuStripTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewContent
            // 
            this.listViewContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewContent.CellEditUseWholeCell = false;
            this.listViewContent.DataSource = null;
            this.listViewContent.EmptyListMsg = "No docsets was found";
            this.listViewContent.FullRowSelect = true;
            this.listViewContent.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewContent.Location = new System.Drawing.Point(3, 0);
            this.listViewContent.MultiSelect = false;
            this.listViewContent.Name = "listViewContent";
            this.listViewContent.ShowGroups = false;
            this.listViewContent.Size = new System.Drawing.Size(186, 432);
            this.listViewContent.TabIndex = 0;
            this.listViewContent.UseCompatibleStateImageBehavior = false;
            this.listViewContent.View = System.Windows.Forms.View.Details;
            this.listViewContent.VirtualMode = true;
            this.listViewContent.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewContent_MouseDoubleClick);
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(3, 3);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.Controls.Add(this.listViewContent);
            this.splitContainerMain.Panel1.Controls.Add(this.textBoxSearch);
            this.splitContainerMain.Panel1MinSize = 192;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.tabControlMain);
            this.splitContainerMain.Size = new System.Drawing.Size(618, 435);
            this.splitContainerMain.SplitterDistance = 192;
            this.splitContainerMain.TabIndex = 1;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSearch.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBoxSearch.Location = new System.Drawing.Point(0, 0);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(192, 20);
            this.textBoxSearch.TabIndex = 1;
            this.textBoxSearch.Tag = "Search...";
            this.textBoxSearch.Text = "Search...";
            this.textBoxSearch.Visible = false;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            this.textBoxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxSearch_KeyDown);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.ImageList = this.imageListIcons;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(422, 435);
            this.tabControlMain.TabIndex = 0;
            this.tabControlMain.Visible = false;
            // 
            // imageListIcons
            // 
            this.imageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListIcons.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStripTab
            // 
            this.contextMenuStripTab.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeTabToolStripMenuItem});
            this.contextMenuStripTab.Name = "contextMenuStripTab";
            this.contextMenuStripTab.Size = new System.Drawing.Size(104, 26);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeTabToolStripMenuItem.Text = "&Close";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.splitContainerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZDocs";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listViewContent)).EndInit();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.contextMenuStripTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private BrightIdeasSoftware.FastDataListView listViewContent;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.ImageList imageListIcons;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTab;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
    }
}

