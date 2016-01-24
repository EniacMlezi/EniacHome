using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EniacHome.Plugins;

namespace EniacHome.Plugins.TemplatePlugin.Controllers
{
    public class WidgetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
