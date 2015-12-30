using PluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_default.ModuleManager
{
    public class ModuleManager
    {
        public ModuleManager()
        {
            Modules = new Dictionary<Module, IPlugin>();
        }

        private static ModuleManager _current;
        public static ModuleManager Current
        {
            get { return _current ?? (_current = new ModuleManager()); }
        }

        internal Dictionary<Module, IPlugin> Modules { get; set; }

        public IEnumerable<Module> GetModules()
        {
            return Modules.Select(m => m.Key).ToList();
        }

        public Dictionary<Module, IPlugin> GetModulesDictionary()
        {
            return Modules;
        }

        public Module GetModule(string name)
        {
            return GetModules().Where(m => m.Name == name).FirstOrDefault();
        }

        public KeyValuePair<Module, IPlugin> GetModuleDictionary(string ModuleName)
        {
            return Modules.Where(m => m.Key.Name == ModuleName).FirstOrDefault();
        }

        public bool Add(Module module, string plugin)
        {
            IPlugin Plugin = PluginManager.PluginManager.Current.GetPlugin(plugin);
            if (Plugin != null)
            {
                Modules.Add(module, Plugin);
                return true;
            }

            return false;
        }
    }
}
