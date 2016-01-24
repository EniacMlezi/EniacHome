using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EniacHome.Models;
using System.ComponentModel.Composition;
using PluginInterface;
using EniacHome.PluginManager;
using System.Collections;
using EniacHome.ModuleManager;

namespace EniacHome.Controllers
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
            IEnumerable<ModuleListViewModel> mModel = modules.Select(x => new ModuleListViewModel { IP = x.Socket.RemoteEndPoint.ToString(), Name = x.Name });
            return View(new PluginAndModuleListViewModule { Plugins = pModel.ToList(), Modules = mModel.ToList() });
        }
    }
}