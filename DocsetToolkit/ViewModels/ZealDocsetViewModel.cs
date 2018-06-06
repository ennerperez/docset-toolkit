using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Toolkit.ViewModels
{
    internal class ZealDocsetViewModel
    {
    	
    	public ZealDocsetViewModel()
    	{
    		Versions  = new HashSet<string>();
    	}
    	
    	public string Id { get; set; }
        public string SourceId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public ICollection<string> Versions { get; set; }
		public long Revision { get; set; }
		public string Icon {get;set;}
		public string Icon2X {get;set;}
		
		//public IDictionary<string, string> Extra {get;set;}
		
        public static Image GetIcon()
        {
            //System.Text.Encoding.Default
            return null;
        }
    }
}