using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_default.Models
{
    public class WidgetListViewModel
    {
        public List<WidgetViewModel> Widgets { get; set; }
    }

    public class WidgetViewModel
    {
        public string Title { get; set; }
        public string WidgetAreaName { get; set; }
        public string IP { get; set; }
    }
}