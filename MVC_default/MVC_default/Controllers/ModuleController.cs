using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_default.Modules;
using MVC_default.Models;
using System.ComponentModel.Composition;
using PluginInterface;
using MVC_default.PluginManager;

namespace MVC_default.Controllers
{
    [Authorize(Roles = "User")]
    public class ModuleController : Controller
    {
        // GET: Module
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            IEnumerable<IPlugin> modules = PluginManager.PluginManager.Current.GetPlugins();
            
            IEnumerable<PluginListViewModel> model = modules.Select(x => new PluginListViewModel { Title = x.Title, Author = x.Author, Version = x.Version.ToString() });

            return View(model);
        }
    }
}