using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using ZDocs.Core.Contexts;
using ZDocs.Core.Models;

namespace ZDocs.Core
{
    public class Program
    {
        public static ICollection<Docset> Doctsets { get; set; }

        public static void LoadDocsets(string source = "docsets")
        {
            if (!Directory.Exists(source)) Directory.CreateDirectory(source);

            Doctsets = new HashSet<Docset>();

            var docsetDir = new DirectoryInfo(source);
#if DEBUG
            docsetDir = new DirectoryInfo(@"C:\Program Files\Zeal\docsets");
#endif
            var collectiom = docsetDir.GetDirectories("*.docset");

            foreach (var item in collectiom)
            {
                var contents = new DirectoryInfo(Path.Combine(item.FullName, "Contents"));
                var resources = new DirectoryInfo(Path.Combine(contents.FullName, "Resources"));

                var meta = Path.Combine(item.FullName, "meta.json");
                var icons = item.GetFiles("*.png");
                var plist = Path.Combine(contents.FullName, "Info.plist");
                var license = Path.Combine(resources.FullName, "LICENSE");

                var docSet = Newtonsoft.Json.JsonConvert.DeserializeObject<Docset>(File.ReadAllText(meta));

                docSet.Path = contents.FullName;

                var plistBuffer = File.ReadAllBytes(plist);
                docSet.Plist = PListNet.PList.Load(new MemoryStream(plistBuffer));

                if (File.Exists(license)) docSet.License = File.ReadAllText(license);
                docSet.Icons = icons.Select(m => m.FullName).ToList();

                Doctsets.Add(docSet);
            }
        }

        public static ICollection<Index> LoadDocsetIndex(Docset source)
        {
            var index = new List<Index>();

            var resources = new DirectoryInfo(Path.Combine(source.Path, "Resources"));

            var dsidx = Path.Combine(resources.FullName, "docSet.dsidx");
            var nodes = Path.Combine(resources.FullName, "Tokens.xml");

            if (File.Exists(nodes))
            {
                var serializer = new XmlSerializer(typeof(Tokens));
                var reader = new StreamReader(nodes);
                var tokens = (Tokens)serializer.Deserialize(reader);
                reader.Close();
                index = (from token in tokens.Token
                         select new Index()
                         {
                             Name = token.TokenIdentifier.Name,
                             Type = token.TokenIdentifier.Type,
                             Path = token.Path
                         }).ToList();
            }
            else
            {
                using (var context = IndexContext.Create("Data Source=" + dsidx + ";"))
                {
                    index = context.SearchIndex.ToList();
                }
            }
            return index;
        }
    }
}