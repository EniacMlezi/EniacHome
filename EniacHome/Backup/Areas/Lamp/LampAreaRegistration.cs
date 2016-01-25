using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace EniacHome.Plugins.LampPlugin
{
    public class LampAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Lamp"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Lamp_default",
                "Lamp/{controller}/{action}/{id}",
                new { action="Index", id=UrlParameter.Optional }
                );
        }
}
}
