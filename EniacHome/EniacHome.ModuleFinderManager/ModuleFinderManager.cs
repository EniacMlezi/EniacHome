using ModuleFinderInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EniacHome.ModuleFinderManager
{
    public class ModuleFinderManager
    {
        public ModuleFinderManager()
        {
            ModuleFinders = new List<IModuleFinder>();
        }

        private static ModuleFinderManager _current;
        public static ModuleFinderManager Current
        {
            get { return _current ?? (_current = new ModuleFinderManager()); }
        }

        internal List<IModuleFinder> ModuleFinders;

        public IEnumerable<IModuleFinder> GetModuleFinders()
        {
            return ModuleFinders;
        }

        public IModuleFinder GetModuleFinder(string name)
        {
            return GetModuleFinders().Where(m => m.Name == name).FirstOrDefault();
        }

        public void Reload()
        {
            // IIS reload, force a rebuild.
        }
    }
}
