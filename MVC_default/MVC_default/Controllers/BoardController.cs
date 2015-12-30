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
            System.Net.IPAddress localIP = System.Net.IPAddress.Parse("127.0.0.1");
            var Modules = ModuleManager.ModuleManager.Current.GetModulesDictionary();
            var widgets = Modules.Select(x => new WidgetViewModel { Title = x.Key.Name, WidgetAreaName = x.Value.EntryAreaName, IP = x.Key.IP.ToString() }).ToList();

            return View(new WidgetListViewModel { Widgets = widgets });        
        }
    }
}