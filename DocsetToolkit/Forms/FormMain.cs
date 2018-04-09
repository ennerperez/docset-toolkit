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

            Icon = Icon.ExtractAssociatedIcon(Program.Assembly.Location);

            // Icons
            toolStripButtonFile.SetImage(MaterialDesign.Instance, Program.Icon, 48, SystemColors.Control);
            toolStripButtonDocsets.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.code, 48, SystemColors.Control);

            toolStripButtonUpdates.SetImage(MaterialDesign.Instance, MaterialDesign.IconType.system_update_alt, 48, SystemColors.Control);

#if DEBUG
            FormHelper.ExtractResources(toolStripMenu);
#endif

            cef = new ChromiumWebBrowser(string.Empty) { Dock = DockStyle.Fill, ContextMenu = null };

            Controls.Add(cef);
            cef.BringToFront();
        }

        private async void FormMain_Shown(object sender, System.EventArgs e)
        {
#if DEBUG
            cef.Load("about:dino");
#endif

            if (string.IsNullOrEmpty(Properties.Settings.Default.DocsetsPath))
                using (var folderBrowserDialog = new FolderBrowserDialog())
                {
                    if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                    {
                        Properties.Settings.Default.DocsetsPath = folderBrowserDialog.SelectedPath;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        MessageBox.Show("You must select a valid Docset path.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Environment.Exit(0);
                    }
                }

            await Task.Run(() => Program.LoadDocsets(Properties.Settings.Default.DocsetsPath));

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
            //if (string.IsNullOrEmpty(textBoxSearch.Text))
            //textBoxSearch.Text = textBoxSearch.Tag.ToString();
        }

        private void TextBoxSearch_GotFocus(object sender, System.EventArgs e)
        {
            //if (textBoxSearch.Text == textBoxSearch.Tag.ToString())
            //textBoxSearch.Text = string.Empty;
        }

        private void textBoxSearch_TextChanged(object sender, System.EventArgs e)
        {
            //if (textBoxSearch.Text == textBoxSearch.Tag.ToString())
            //textBoxSearch.ForeColor = System.Drawing.SystemColors.ControlDark;
            //else
            //textBoxSearch.ForeColor = System.Drawing.SystemColors.ControlText;
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

        private CefSharp.WinForms.ChromiumWebBrowser cef;

        private void button_Click(object sender, EventArgs e)
        {
            var item = (sender as ToolStripItem);
            var id = int.Parse(item.Tag.ToString());
            var docset = Program.Doctsets.FirstOrDefault(m => m.Id == id);
            var plist = docset.Plist as DictionaryNode;
            var dashIndexFilePath = string.Empty;
            if (plist.ContainsKey("dashIndexFilePath"))
                dashIndexFilePath = Path.Combine(docset.Path, "Resources", "Documents", (plist["dashIndexFilePath"] as StringNode).Value);
            else
                dashIndexFilePath = Path.Combine(docset.Path, "Resources", "Documents", (plist["DocSetPlatformFamily"] as StringNode).Value, "index.html");

            cef.Load(dashIndexFilePath);
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
    }
}