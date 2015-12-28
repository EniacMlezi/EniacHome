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
using System.Collections;
using MVC_default.ModuleManager;

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
            IEnumerable<IPlugin> plugins = PluginManager.PluginManager.Current.GetPlugins();           
            IEnumerable<PluginListViewModel> pModel = plugins.Select(x => new PluginListViewModel { Title = x.Title, Author = x.Author, Version = x.Version.ToString() });

            IEnumerable<Module> modules = ModuleManager.ModuleManager.Current.GetModules();
            IEnumerable<ModuleListViewModel> mModel = modules.Select(x => new ModuleListViewModel { IP = x.IP.ToString(), Name = x.Name });
            return View(new PluginAndModuleListViewModule { Plugins = pModel.ToList(), Modules = mModel.ToList() });
        }
    }
}