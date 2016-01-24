using PluginInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniacHome.ModuleManager
{
    public class ModuleManager
    {
        public ModuleManager()
        {
            Modules = new List<Module>();
        }

        private static ModuleManager _current;
        public static ModuleManager Current
        {
            get { return _current ?? (_current = new ModuleManager()); }
        }

        internal List<Module> Modules { get; set; }

        public IEnumerable<Module> GetModules()
        {
            return Modules;
        }

        public Module GetModule(string name)
        {
            return GetModules().Where(m => m.Name == name).FirstOrDefault();
        }

        public void Add(Module module)
        {
            File.AppendAllText(@"C:\log.txt", System.DateTime.Now.ToString() + " -> [ModuleManager] Adding Module: " + module.Name + " | " + module.Plugin.Name + Environment.NewLine);
            if (ModuleManager.Current.GetModule(module.Name) == null && PluginManager.PluginManager.Current.GetPlugin(module.Plugin) != null)
            {
                File.AppendAllText(@"C:\log.txt", System.DateTime.Now.ToString() + " -> [ModuleManager] Added ModuleDEBUG: " + module.Name + " | " + module.Plugin.Name + Environment.NewLine);
                Modules.Add(module);
                File.AppendAllText(@"C:\log.txt", System.DateTime.Now.ToString() + " -> [ModuleManager] Added Module: " + module.Name + " | " + module.Plugin.Name + Environment.NewLine);
            }
        }

        public void Delete(IPlugin plugin)
        {
            Delete(Modules.Where(x => x.Plugin.GetType() == plugin.GetType()));
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