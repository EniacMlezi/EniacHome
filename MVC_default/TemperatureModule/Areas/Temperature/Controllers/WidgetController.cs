using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC_default.Plugins;

namespace MVC_default.Plugins.TemperatureModule.Controllers
{
    //[RoutePrefix("Temperature")]
    //[Route("")]
    public class WidgetController : Controller
    {

        //[Route("Temperature/Index")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
