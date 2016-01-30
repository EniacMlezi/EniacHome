using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EniacHome.Areas.Admin.Models;
using ModuleFinderInterface;

namespace EniacHome.Areas.Admin.Controllers
{

    public class ModuleFinderController : Controller
    {
        [Authorize(Roles = "Administrator, Moderator")]
        // GET: Admin/ModuleFinder
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            IEnumerable<IModuleFinder> moduleFinders = ModuleFinderManager.ModuleFinderManager.Current.GetModuleFinders();
            IEnumerable<ModuleFinderDetailsViewModel> model = moduleFinders.Select(x => new ModuleFinderDetailsViewModel {
                Name = x.Name,
                Author = x.Author,
                Version = x.Version.ToString(),
                IsListening = x.IsListening
            });
            return View(model);
        }

        public ActionResult Details(string Name)
        {
            IModuleFinder moduleFinder = ModuleFinderManager.ModuleFinderManager.Current.GetModuleFinder(Name);
            ModuleFinderDetailsViewModel model = new ModuleFinderDetailsViewModel
            {
                Name = moduleFinder.Name,
                Author = moduleFinder.Author,
                Version = moduleFinder.Version.ToString(),
                IsListening = moduleFinder.IsListening
            };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public ActionResult Delete(string Name)
        {
            System.IO.File.Delete(Server.MapPath("~/plugins/" + Name + ".dll"));
            ModuleFinderManager.ModuleFinderManager.Current.Reload();
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
            ModuleFinderManager.ModuleFinderManager.Current.Reload();
            return RedirectToAction("List");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public void ToggleListening(string Name)
        {
            IModuleFinder ModuleFinder = ModuleFinderManager.ModuleFinderManager.Current.GetModuleFinder(Name);
            if (!ModuleFinder.IsListening)           
                ModuleFinder.StartListening();           
            else           
                ModuleFinder.StopListening();
        }
    }
}