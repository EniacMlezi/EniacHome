using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using PluginInterface;
using System.Diagnostics;
using Microsoft.Web.Administration;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;
using System.Web.Hosting;

namespace MVC_default.PluginManager
{
    public class PluginManager
    {
        public PluginManager()
        {
            Plugins = new Dictionary<IPlugin, Assembly>();
        }

        private static PluginManager _current;
        public static PluginManager Current
        {
            get { return _current ?? (_current = new PluginManager()); }
        }

        internal Dictionary<IPlugin, Assembly> Plugins { get; set; }

        public IEnumerable<IPlugin> GetPlugins()
        {
            return Plugins.Select(m => m.Key).ToList();
        }

        public IPlugin GetPlugin(string name)
        {
            return GetPlugins().Where(m => m.Name == name).FirstOrDefault();
        }
        
        public void Reload()
        {
            using (ServerManager iisManager = new ServerManager())
            {
                SiteCollection sites = iisManager.Sites;
                foreach (Site site in sites)
                {
                    if (site.Name == HostingEnvironment.ApplicationHost.GetSiteName())
                    {
                        iisManager.ApplicationPools[site.Applications["/"].ApplicationPoolName].Recycle();
                        break;
                    }
                }
            }
        }
    }
}
