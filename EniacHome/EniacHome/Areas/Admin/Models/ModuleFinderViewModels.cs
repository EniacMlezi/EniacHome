using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EniacHome.Areas.Admin.Models
{
    public class ModuleFinderListViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
    }

    public class ModuleFinderDetailsViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }

        public bool IsListening { get; set; }
    }
}