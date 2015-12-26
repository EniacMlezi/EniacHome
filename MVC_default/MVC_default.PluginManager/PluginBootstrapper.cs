using System.Web;
using System.Web.Routing;

namespace MVC_default.PluginManager
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
                BoC.Web.Mvc.PrecompiledViews.ApplicationPartRegistry.Register(asmbly);
            }
        }
    }
}
