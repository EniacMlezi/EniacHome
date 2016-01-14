using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PluginInterface;
using MVC_default.Areas.Admin.Models;
using System.IO;

namespace MVC_default.Areas.Admin.Controllers
{
    public class PluginController : Controller
    {
        // GET: Admin/Plugin
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            IEnumerable<IPlugin> modules = PluginManager.PluginManager.Current.GetPlugins();
            IEnumerable<PluginListViewModel> model = modules.Select(x => new PluginListViewModel { Name = x.Name, Author = x.Author, Version = x.Version.ToString() });

            return View(model);
        }

        public ActionResult Details(string Name)
        {
            IPlugin module = PluginManager.PluginManager.Current.GetPlugin(Name);
            PluginDetailsViewModel model = new PluginDetailsViewModel {
                Title = module.Title,
                Name = module.Name,
                Author = module.Author,
                Version = module.Version.ToString(),
                EntryAreaName = module.EntryAreaName
            };
            return View(model);
        }

        public ActionResult Delete(string Name)
        {
            System.IO.File.Delete(Server.MapPath("~/plugins/" + Name + ".dll"));
            ModuleManager.ModuleManager.Current.Delete(PluginManager.PluginManager.Current.GetPlugin(Name));
            PluginManager.PluginManager.Current.Reload();
            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateHeaderAntiForgeryToken]
        public ActionResult Add()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                HttpPostedFileBase file = Request.Files[i];
                file.SaveAs(Server.MapPath("~/plugins/") + file.FileName);
            }

            return RedirectToAction("List");
        }
    }
}