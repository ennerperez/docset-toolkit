using System.Drawing.Pictograms;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms.Pictograms;
using BrightIdeasSoftware;
using CefSharp.WinForms;
using PListNet.Nodes;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Toolkit.ViewModels;

namespace Toolkit.Forms
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            textBoxSearch.GotFocus += TextBoxSearch_GotFocus;
            textBoxSearch.LostFocus += TextBoxSearch_LostFocus;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;

            Icon = Icon.ExtractAssociatedIcon(Program.Assembly.Location);

            // Icons
            toolStripButtonFile.SetImage(MaterialDesign.Instance, Program.Icon, 48, SystemColors.Control);
            toolStripButtonDocsets.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.code, 48, SystemColors.Control);
            toolStripButtonIndex.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.book, 48, SystemColors.Control);
            toolStripButtonSearch.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.search, 48, SystemColors.Control);

            toolStripButtonUpdates.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.system_update_alt, 48, SystemColors.Control);

            buttonDoSearch.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.search, 32, SystemColors.ControlDarkDark);

#if DEBUG
            FormHelper.ExtractResources(toolStripMenu);
#endif

            treeListViewIndex.Columns.Add(new OLVColumn("Name", "Name") { FillsFreeSpace = true });
            //treeListViewIndex.ParentGetter = (s) => "ParentId";
            //treeListViewIndex.CanExpandGetter = (s) => true;
            //treeListViewIndex.GroupKeyGetter = (s) => (s as Models.Index).ParentId;
            //treeListViewIndex.ShowGroups = true;

            cef = new ChromiumWebBrowser(string.Empty) { Dock = DockStyle.Fill, ContextMenu = null };
            Controls.Add(cef);
            cef.BringToFront();
            panelSearch.BringToFront();
        }

        private async void FormMain_Shown(object sender, System.EventArgs e)
        {
#if DEBUG
            cef.Load("about:dino");
#endif

            if (string.IsNullOrEmpty(Properties.Settings.Default.DocsetsPath))
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    folderBrowserDialog.Description = "Select the Docsets container path:";
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        Properties.Settings.Default.DocsetsPath = folderBrowserDialog.SelectedPath;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("You must select a valid Docsets container path.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }

            await Program.LoadDocsetsAsync(Properties.Settings.Default.DocsetsPath);

            var viewModels = (from item in Program.Doctsets
                              select new DocsetViewModel()
                              {
                                  Id = item.Id,
                                  Title = item.Title,
                                  Version = item.Version,
                                  Icon = item.Icons.LastOrDefault()
                              }).ToList();

            foreach (var item in viewModels)
            {
                var icon = DocsetViewModel.GetIcon(item);
                var button = new ToolStripMenuItem(item.Title + (!string.IsNullOrEmpty(item.Version) ? Environment.NewLine + item.Version : string.Empty)) { Image = icon, Tag = item.Id, ImageScaling = ToolStripItemImageScaling.None };
                button.Click += button_Click;
                toolStripButtonDocsets.DropDownItems.Add(button);
            }
        }

        #region Search

        #region CueText

        private void TextBoxSearch_LostFocus(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSearch.Text))
                textBoxSearch.Text = textBoxSearch.Tag.ToString();
        }

        private void TextBoxSearch_GotFocus(object sender, System.EventArgs e)
        {
            if (textBoxSearch.Text == textBoxSearch.Tag.ToString())
                textBoxSearch.Text = string.Empty;
        }

        private void textBoxSearch_TextChanged(object sender, System.EventArgs e)
        {
            if (textBoxSearch.Text == textBoxSearch.Tag.ToString())
            {
                textBoxSearch.ForeColor = System.Drawing.SystemColors.ControlDark;
                buttonDoSearch.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.search, 32, SystemColors.ControlDarkDark);
            }
            else
            {
                textBoxSearch.ForeColor = System.Drawing.SystemColors.ControlText;
                buttonDoSearch.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.cancel, 32, SystemColors.ControlDarkDark);
            }
        }

        #endregion CueText

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //}
            //else if (e.KeyCode == Keys.Escape)
            //textBoxSearch.Text = string.Empty;
        }

        #endregion Search

        private CefSharp.WinForms.ChromiumWebBrowser cef { get; set; }
        private Models.Docset ActiveDocset { get; set; }

        private async void button_Click(object sender, EventArgs e)
        {
            var item = (sender as ToolStripItem);
            var id = int.Parse(item.Tag.ToString());
            ActiveDocset = Program.Doctsets.FirstOrDefault(m => m.Id == id);
            var plist = ActiveDocset.Plist as DictionaryNode;
            var dashIndexFilePath = string.Empty;
            if (plist.ContainsKey("dashIndexFilePath"))
                dashIndexFilePath = Path.Combine(ActiveDocset.Path, "Resources", "Documents", (plist["dashIndexFilePath"] as StringNode).Value);
            else
                dashIndexFilePath = Path.Combine(ActiveDocset.Path, "Resources", "Documents", (plist["DocSetPlatformFamily"] as StringNode).Value, "index.html");

            cef.Load(dashIndexFilePath);

            treeListViewIndex.Visible = false;

            toolStripButtonIndex.Visible = ActiveDocset != null;
            toolStripButtonIndex.Enabled = false;
            toolStripButtonIndex.Checked = false;

            // Load index cache
            await Program.LoadDocsetIndexAsync(ActiveDocset);
            toolStripButtonIndex.Enabled = ActiveDocset.Index.Any();
        }

        private void ToolStripButtonAbout_Click(object sender, EventArgs e)
        {
            var child = new FormAbout();
            child.ShowDialog();
        }

        private void ToolStripButtonExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ToolStripButtonUpdates_Click(object sender, EventArgs e)
        {
            var checkForUpdates = !toolStripButtonUpdates.Checked;
            toolStripButtonUpdates.Checked = checkForUpdates;
            Properties.Settings.Default.CheckForUpdates = checkForUpdates;
            Properties.Settings.Default.Save();
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            toolStripButtonUpdates.Checked = Properties.Settings.Default.CheckForUpdates;

            if (Properties.Settings.Default.CheckForUpdates)
                await GitHubInfo.CheckForUpdateAsync();
        }

        private void toolStripButtonIndex_CheckStateChanged(object sender, EventArgs e)
        {
            treeListViewIndex.EmptyListMsg = "Loading...";
            treeListViewIndex.Width = (int)(this.Width * .25);
            treeListViewIndex.Visible = toolStripButtonIndex.Checked;
            if (treeListViewIndex.Visible)
            {
                treeListViewIndex.BringToFront();
                treeListViewIndex.SetObjects(ActiveDocset.Index);
                treeListViewIndex.EmptyListMsg = "No content was found";
            }
        }

        private void treeListViewIndex_DoubleClick(object sender, EventArgs e)
        {
            if (treeListViewIndex.SelectedItem != null)
            {
                var model = (treeListViewIndex.SelectedItem.RowObject as Models.Index);
                var dashIndexFilePath = Path.Combine(ActiveDocset.Path, "Resources", "Documents", model.Path);
                cef.Load(dashIndexFilePath);
                toolStripButtonIndex.Checked = false;
            }
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            panelSearch.Visible = toolStripButtonSearch.Checked;
            if (toolStripButtonSearch.Checked)
                textBoxSearch.Focus();
        }
    }
}