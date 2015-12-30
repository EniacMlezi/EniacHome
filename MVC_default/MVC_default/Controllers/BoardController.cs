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
            Modules.Add(new Module { IP = System.Net.IPAddress.Parse("127.0.0.1"), Name = "Temperatuur" }, PluginManager.PluginManager.Current.GetPlugin("TemperatureModule"));
            Modules.Add(new Module { IP = System.Net.IPAddress.Parse("127.0.0.1"), Name = "Template" }, PluginManager.PluginManager.Current.GetPlugin("TemplatePlugin"));
            var widgets = Modules.Select(x => new WidgetViewModel { Title = x.Key.Name, WidgetAreaName = x.Value.EntryAreaName, IP = x.Key.IP.ToString(), Width = x.Value.WidgetWidth }).ToList();

            return View(new WidgetListViewModel { Widgets = widgets });        
        }
    }
}