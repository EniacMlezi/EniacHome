using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVC_default.Plugins.TemplatePlugin
{
    public class TemplateAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get { return "Template"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Template_default",
                "Template/{controller}/{action}/{id}",
                new { action="Index", id=UrlParameter.Optional }
                );
        }
}
}
