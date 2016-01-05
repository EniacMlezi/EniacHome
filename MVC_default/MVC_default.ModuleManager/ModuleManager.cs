using PluginInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ReadOnlyDictionary<Module, IPlugin> GetModulesDictionary()
        {

            Modules.Add(new Module { IP = System.Net.IPAddress.Parse("127.0.0.1"), Name = "Temperatuur" }, PluginManager.PluginManager.Current.GetPlugin("TemperatureModule"));
            Modules.Add(new Module { IP = System.Net.IPAddress.Parse("127.0.0.1"), Name = "Template" }, PluginManager.PluginManager.Current.GetPlugin("TemplatePlugin"));
            return new ReadOnlyDictionary<Module, IPlugin>(Modules);
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

        public void Delete(IPlugin plugin)
        {
            Delete(Modules.Where(x => x.Value.GetType() == plugin.GetType()).Select(y => y.Key));
        }

        public void Delete(IEnumerable<Module> modules)
        {
            foreach (var module in modules.ToList())
            {
                Delete(module);
            }
        }

        public void Delete(Module module)
        {
            Modules.Remove(module);
        }
    }
}
