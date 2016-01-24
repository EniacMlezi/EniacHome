using System;
using System.IO;
using System.Web;
using System.Web.Routing;

namespace EniacHome.PluginManager
{
    public static class PluginBootstrapper
    {
        static PluginBootstrapper()
        {
	        
        }

    	public static void Initialize()
        {
            foreach (var asmbly in PluginManager.Current.Plugins.Values)
	        {
                File.AppendAllText(@"C:\log.txt",  System.DateTime.Now.ToString() + " -> Bootstrapped: " + asmbly.FullName + Environment.NewLine);
                BoC.Web.Mvc.PrecompiledViews.ApplicationPartRegistry.Register(asmbly);
            }
        }
    }
}
