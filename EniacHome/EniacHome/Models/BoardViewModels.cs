using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EniacHome.Models
{
    public class WidgetListViewModel
    {
        public List<WidgetViewModel> Widgets { get; set; }
    }

    public class WidgetViewModel
    {
        public string Title { get; set; }
        public string WidgetAreaName { get; set; }
        public string Address { get; set; }
        
        public string PositionX { get; set; }
        public string PositionY { get; set; }
        public string WidgetWidth { get; set; }
        public string WidgetHeight { get; set; }

    }
}