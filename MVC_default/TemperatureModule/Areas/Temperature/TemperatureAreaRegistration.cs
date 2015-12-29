using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_default.Plugins.TemperatureModule
{
    public class TemperatureAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Temperature"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Temperature_default",
                "Temperature/{controller}/{action}/{id}",
                new { action="Index", id=UrlParameter.Optional }
                );
        }
}
}
