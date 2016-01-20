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
        
        public string PositionX { get; set; }
        public string PositionY { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
    }
}