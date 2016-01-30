using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EniacHome.Models;
using EniacHome.ModuleManager;
using System.Web.Script.Serialization;

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
                PositionX = (Request.Cookies["Dashboard"] == null) ? null : Request.Cookies["Dashboard"][x.Name].Split(',')[0],
                PositionY = (Request.Cookies["Dashboard"] == null) ? null : Request.Cookies["Dashboard"][x.Name].Split(',')[1]
            }).ToList();

            return View(new WidgetListViewModel { Widgets = widgets });
        }

        private struct widget
        {
            public string Name { get; set; }
            public string x { get; set; }
            public string y { get; set; }
        }
        public void UpdateCookie(string[] widgets)
        {
            HttpCookie DashboardCookie = new HttpCookie("Dashboard");
            foreach (string widget in widgets)
            {
                widget objWidget = new JavaScriptSerializer().Deserialize<widget>(widget);
                DashboardCookie[objWidget.Name] = objWidget.x + "," + objWidget.y;
            }
            DashboardCookie.Expires = DateTime.Now.AddYears(10);
            Response.Cookies.Add(DashboardCookie);  
            return;
        }
    }
}