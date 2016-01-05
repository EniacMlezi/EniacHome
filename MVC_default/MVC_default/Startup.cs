using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.IO;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(MVC_default.Startup))]
namespace MVC_default
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
