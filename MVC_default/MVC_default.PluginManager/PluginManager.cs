using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using PluginInterface;


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
            System.Web.HttpRuntime.UnloadAppDomain();
        }
    }
}