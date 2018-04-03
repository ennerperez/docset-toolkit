using BrightIdeasSoftware;
using CefSharp.WinForms;
using PListNet.Nodes;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ZDocs.Shell.ViewModels;
using static ZDocs.Core.Program;

namespace ZDocs.Shell
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            textBoxSearch.GotFocus += TextBoxSearch_GotFocus;
            textBoxSearch.LostFocus += TextBoxSearch_LostFocus;
            tabControlMain.TabIndexChanged += TabControlMain_TabIndexChanged;
        }

        private void FormMain_Load(object sender, System.EventArgs e)
        {
            var viewModels = (from item in Doctsets
                              select new DocsetViewModel()
                              {
                                  Id = item.Id,
                                  Title = item.Title,
                                  Version = item.Version,
                                  Icon = item.Icons.FirstOrDefault()
                              }).ToList();

            var titleColumn = new OLVColumn() { Text = "Title", AspectName = "Title", FillsFreeSpace = true };
            titleColumn.ImageGetter = new ImageGetterDelegate(DocsetViewModel.GetIcon);

            var versionColumn = new OLVColumn() { Text = "Version", AspectName = "Version", FillsFreeSpace = true };

            listViewContent.Columns.AddRange(new[] { titleColumn, versionColumn });
            listViewContent.SetObjects(viewModels);

            foreach (var item in viewModels)
            {
                var icon = DocsetViewModel.GetIcon(item);
                imageListIcons.Images.Add(icon);
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
                textBoxSearch.ForeColor = System.Drawing.SystemColors.ControlDark;
            else
                textBoxSearch.ForeColor = System.Drawing.SystemColors.ControlText;
        }

        #endregion CueText

        private void textBoxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            }
            else if (e.KeyCode == Keys.Escape)
                textBoxSearch.Text = string.Empty;
        }

        #endregion Search

        private void TabControlMain_TabIndexChanged(object sender, System.EventArgs e)
        {
            tabControlMain.Visible = tabControlMain.TabPages.Count > 0;
        }

        private void listViewContent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewContent.SelectedItem != null)
            {
                var model = (listViewContent.SelectedItem.RowObject as DocsetViewModel);
                var docset = Doctsets.FirstOrDefault(m => m.Id == model.Id);
                var plist = docset.Plist as DictionaryNode;
                var dashIndexFilePath = string.Empty;
                if (plist.ContainsKey("dashIndexFilePath"))
                    dashIndexFilePath = Path.Combine(docset.Path, "Resources", "Documents", (plist["dashIndexFilePath"] as StringNode).Value);
                else
                    dashIndexFilePath = Path.Combine(docset.Path, "Resources", "Documents", (plist["DocSetPlatformFamily"] as StringNode).Value, "index.html");

                var tab = new TabPage(docset.Title + " ") { BackColor = Color.White, ImageIndex = (model.Id - 1) };
                var cef = new ChromiumWebBrowser(dashIndexFilePath) { Dock = DockStyle.Fill };
                tab.Controls.Add(cef);
                tabControlMain.TabPages.Add(tab);
                tabControlMain.SelectedTab = tab;
                TabControlMain_TabIndexChanged(sender, EventArgs.Empty);
            }
        }

        //private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    var tab = ((contextMenuStripTab.SourceControl as ChromiumWebBrowser).Parent as TabPage);
        //    tabControlMain.TabPages.Remove(tab);
        //    TabControlMain_TabIndexChanged(sender, EventArgs.Empty);
        //}
    }
}