using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC_default.Plugins;

namespace MVC_default.Plugins.TemplatePlugin.Controllers
{
    public class WidgetController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
