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
            var Modules = ModuleManager.ModuleManager.Current.GetModules();
            //var widgets = Modules.Select(x => new WidgetViewModel {
            //    Title = x.Key.Name,
            //    WidgetAreaName = x.Value.EntryAreaName,
            //    IP = x.Key.IP.ToString(),
            //    Width = x.Value.WidgetWidth,
            //    Height = x.Value.WidgetHeight,
            //    //PositionX = 
            //    //PositionY =
            //}).ToList();

            List<WidgetViewModel> widgets = new List<WidgetViewModel>();
            widgets.Add(new WidgetViewModel { Title = "testTemp", WidgetAreaName="Temperature", IP= "halloHACK", Width="6", Height="8" });
            widgets.Add(new WidgetViewModel { Title = "testTemp", WidgetAreaName = "Temperature", IP = "halloHACK", Width="8", Height="5" });
            widgets.Add(new WidgetViewModel { Title = "testTemp", WidgetAreaName = "Template", IP = "halloHACK", Width="3", Height="2" });

            return View(new WidgetListViewModel { Widgets = widgets });        
        }
    }
}