using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EniacHome.Models;
using EniacHome.ModuleManager;

namespace EniacHome.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        // GET: Board
        public ActionResult Index()
        {   
            var Modules = ModuleManager.ModuleManager.Current.GetModules();
            var widgets = Modules.Select(x => new WidgetViewModel
            {
                Title = x.Name,
                WidgetAreaName = x.Plugin.EntryAreaName,
                IP = x.Socket.RemoteEndPoint.ToString(),
                WidgetWidth = x.Plugin.WidgetWidth,
                WidgetHeight = x.Plugin.WidgetHeight,
                //PositionX = 
                //PositionY =
            }).ToList();

            return View(new WidgetListViewModel { Widgets = widgets });
        }
    }
}