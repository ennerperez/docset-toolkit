using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Serialization;
using CefSharp;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Toolkit.Contexts;
using Toolkit.Models;
using System.Threading.Tasks;
using System.Data.Entity;
using Toolkit.ViewModels;

namespace Toolkit
{
    internal static partial class Program
    {
        internal static bool IsNewInstance = false;
        internal static Mutex Mutex = new Mutex(true, ApplicationInfo.Guid, out IsNewInstance);
        internal static Assembly Assembly = Assembly.GetExecutingAssembly();

#if NETFX_46
        internal static Dictionary<string, string> CommandArgs => ApplicationInfo.GetCommandLine();
#else
        internal static Dictionary<string, string> CommandArgs { get { return ApplicationInfo.GetCommandLine(); } }
#endif

        [STAThread]
        private static void Main()
        {
            Initialize();

            AppDomain.CurrentDomain.AssemblyResolve += Resolver;
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var zeal = LoadExternalsDocsets();
            
            if (IsNewInstance)
                LoadApp();
            else
                NewInstanceHandler(null, EventArgs.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void LoadApp()
        {
            var settings = new CefSettings
            {
                // Set BrowserSubProcessPath based on app bitness at runtime
                BrowserSubprocessPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                   Environment.Is64BitProcess ? "x64" : "x86",
                                                   "CefSharp.BrowserSubprocess.exe")
            };

            // Make sure you set performDependencyCheck false
            if (!Cef.IsInitialized)
                Cef.Initialize(settings, performDependencyCheck: false, browserProcessHandler: null);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Forms.FormMain());
        }

        // Will attempt to load missing assembly from either x86 or x64 subdir
        private static Assembly Resolver(object sender, ResolveEventArgs args)
        {
            if (args.Name.StartsWith("CefSharp"))
            {
                string assemblyName = args.Name.Split(new[] { ',' }, 2)[0] + ".dll";
                string archSpecificPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
                                                       Environment.Is64BitProcess ? "x64" : "x86",
                                                       assemblyName);

                return File.Exists(archSpecificPath) ? Assembly.LoadFile(archSpecificPath) : null;
            }

            return null;
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
        }

        private static void NewInstanceHandler(object sender, EventArgs e)
        {
#if NETFX_46
            NewInstance?.Invoke(sender, e);
#else
            if (NewInstance != null)
                NewInstance.Invoke(sender, e);
#endif
        }

        public static event EventHandler NewInstance;

        public static ICollection<Docset> Doctsets { get; private set; }

        public static void LoadDocsets(string source = "docsets")
        {
            if (!Directory.Exists(source)) Directory.CreateDirectory(source);

            Doctsets = new HashSet<Docset>();

            var docsetDir = new DirectoryInfo(source);
            var collectiom = docsetDir.GetDirectories("*.docset");

            var index = 1;
            foreach (var item in collectiom)
            {
                var contents = new DirectoryInfo(Path.Combine(item.FullName, "Contents"));
                var resources = new DirectoryInfo(Path.Combine(contents.FullName, "Resources"));

                var meta = Path.Combine(item.FullName, "meta.json");
                var icons = item.GetFiles("*.png");
                var plist = Path.Combine(contents.FullName, "Info.plist");
                var license = Path.Combine(resources.FullName, "LICENSE");

                var docSet = Newtonsoft.Json.JsonConvert.DeserializeObject<Docset>(File.ReadAllText(meta));
                docSet.Id = index;

                docSet.Path = contents.FullName;

                var plistBuffer = File.ReadAllBytes(plist);
                docSet.Plist = PListNet.PList.Load(new MemoryStream(plistBuffer));

                if (File.Exists(license)) docSet.License = File.ReadAllText(license);
                docSet.Icons = icons.Select(m => m.FullName).ToList();

                Doctsets.Add(docSet);
                index++;
            }

            if (Doctsets != null && Doctsets.Any())
                LoadDocsetIndex(Doctsets.First());
        }

        public static void LoadDocsetIndex(Docset source)
        {
            if (source.Index != null && source.Index.Any())
                return;

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
                using (var context = IndexContext.Create("Data Source=" + dsidx + ";"))
                    index = context.SearchIndex.ToList();
            source.Index = index;
        }

        public static async Task LoadDocsetsAsync(string source = "docsets")
        {
            if (!Directory.Exists(source)) Directory.CreateDirectory(source);

            Doctsets = new HashSet<Docset>();

            var docsetDir = new DirectoryInfo(source);
            var collectiom = docsetDir.GetDirectories("*.docset");

            var index = 1;
            foreach (var item in collectiom)
            {
                var contents = new DirectoryInfo(Path.Combine(item.FullName, "Contents"));
                var resources = new DirectoryInfo(Path.Combine(contents.FullName, "Resources"));

                var meta = Path.Combine(item.FullName, "meta.json");
                var icons = item.GetFiles("*.png");
                var plist = Path.Combine(contents.FullName, "Info.plist");
                var license = Path.Combine(resources.FullName, "LICENSE");

                var docSet = Newtonsoft.Json.JsonConvert.DeserializeObject<Docset>(File.ReadAllText(meta));
                docSet.Id = index;

                docSet.Path = contents.FullName;

                var plistBuffer = File.ReadAllBytes(plist);
                docSet.Plist = PListNet.PList.Load(new MemoryStream(plistBuffer));

                if (File.Exists(license)) docSet.License = File.ReadAllText(license);
                docSet.Icons = icons.Select(m => m.FullName).ToList();

                Doctsets.Add(docSet);
                index++;
            }

            if (Doctsets != null && Doctsets.Any())
                await LoadDocsetIndexAsync(Doctsets.First());
        }

        public static async Task LoadDocsetIndexAsync(Docset source)
        {
            if (source.Index != null && source.Index.Any())
                return;

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
                using (var context = IndexContext.Create("Data Source=" + dsidx + ";"))
                    index = await context.SearchIndex.ToListAsync();
            source.Index = index;
        }
    
    	public static IEnumerable<DocsetViewModel> LoadExternalsDocsets()
		{
    		var results = new List<DocsetViewModel>();
			var zeal_result = new List<ZealDocsetViewModel>();
			#if DEBUG
			var json = System.IO.File.ReadAllText(@"..\..\data\zeal.json");
			zeal_result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ZealDocsetViewModel>>(json);
			#endif
			results.AddRange((from item in zeal_result
			                 select new DocsetViewModel()
			                 {
			                 	 Title = item.Title,
			                 	 Icon = item.Icon2X,
			                 	 Version = item.Versions.Where(m=> !string.IsNullOrEmpty(m)).Max(m=> m) // Version.Parse(m)).ToString()
			                 }).ToArray());
			return results;
		}
    }
}