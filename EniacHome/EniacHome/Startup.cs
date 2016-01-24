using Microsoft.Owin;
using Owin;
using System.Collections.Generic;
using System.IO;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using System.Web;

[assembly: OwinStartupAttribute(typeof(EniacHome.Startup))]
namespace EniacHome
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
