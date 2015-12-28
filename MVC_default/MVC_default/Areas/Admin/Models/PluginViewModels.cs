using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace MVC_default.Areas.Admin.Models
{
    public class PluginListViewModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
    }

    public class PluginDetailsViewModel
    {
        public string Title { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
        public string EntryAreaName { get; set; }
    }
}