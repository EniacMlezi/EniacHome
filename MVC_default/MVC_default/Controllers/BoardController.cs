using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_default.Models;
using MVC_default.ModuleManager;

namespace MVC_default.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult Index()
        {
            var Modules = ModuleManager.ModuleManager.Current.GetModulesDictionary();
            //var widgets = Modules.Select(x => new WidgetViewModel { Title = x.Key.Name, WidgetAreaName = x.Value.EntryAreaName, IP = x.Key.IP.ToString(),  }).ToList();

            List<WidgetViewModel> widgets = new List<WidgetViewModel>();
            widgets.Add(new WidgetViewModel { Title = "testTemp", WidgetAreaName="Temperature", IP= "halloHACK", Size="2" });
            widgets.Add(new WidgetViewModel { Title = "testTemp", WidgetAreaName = "Temperature", IP = "halloHACK", Size="4" });
            widgets.Add(new WidgetViewModel { Title = "testTemp", WidgetAreaName = "Template", IP = "halloHACK", Size="3" });

            return View(new WidgetListViewModel { Widgets = widgets });        
        }
    }
}