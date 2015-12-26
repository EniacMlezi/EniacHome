﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace MVC_default.Models
{
    public class PluginListViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Version { get; set; }
    }

    public class ModuleListViewModel
    {
        public string Name { get; set; }

        public string Version { get; set; }
    }
}