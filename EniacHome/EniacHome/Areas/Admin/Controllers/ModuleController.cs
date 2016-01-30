using EniacHome.Areas.Admin.Models;
using ModuleInterface;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EniacHome.Areas.Admin.Controllers
{
    public class ModuleController : Controller
    {
        // GET: Admin/Module
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public ActionResult List()
        {
            IEnumerable<IModule> modules = ModuleManager.ModuleManager.Current.GetModules();
            IEnumerable<ModuleListViewModel> model = modules.Select(x => new ModuleListViewModel { Address = x.Address, Name = x.Name });
            return View(model);
        }

        public ActionResult Delete(string Name)
        {
            ModuleManager.ModuleManager.Current.Delete(Name);
            return RedirectToAction("List");
        }
    }
}