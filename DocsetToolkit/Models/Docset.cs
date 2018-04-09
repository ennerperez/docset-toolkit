using Newtonsoft.Json;
using PListNet;
using System.Collections.Generic;

namespace Toolkit.Models
{
    public class Docset
    {
        public Docset()
        {
            Index = new HashSet<Index>();
        }

        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Revision { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }

        public override string ToString()
        {
            return Title ?? base.ToString();
        }

        [JsonIgnore]
        public string Path { get; set; }

        [JsonIgnore]
        public ICollection<Index> Index { get; set; }

        [JsonIgnore]
        public ICollection<string> Icons { get; set; }

        [JsonIgnore]
        public string License { get; set; }

        [JsonIgnore]
        public PNode Plist { get; set; }
    }
}