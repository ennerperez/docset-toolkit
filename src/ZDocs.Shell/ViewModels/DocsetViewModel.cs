using System.Drawing;
using System.IO;

namespace ZDocs.Shell.ViewModels
{
    internal class DocsetViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Version { get; set; }

        public static Image GetIcon(object source)
        {
            var file = (source as DocsetViewModel).Icon;
            if (File.Exists(file))
            {
                return Image.FromFile(file);
            }
            return null;
        }
    }
}