using PluginInterface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EniacHome.ModuleManager
{
    public class ModuleManager
    {
        public ModuleManager()
        {
            Modules = new List<Module>();
            Thread Polling = new Thread(CheckModules);
            Polling.Start();
        }

        public static bool IsConnected(Socket socket)
        {
            try
            {
                socket.Send(new byte[] { 0 });
            }
            catch
            {
                return false;
            }
            return true;
        }

        private static void CheckModules()
        {
            while (true)
            {
                System.Threading.Thread.Sleep(3000);
                foreach (var module in Current.Modules.ToList())
                {
                    if (!IsConnected(module.Socket))
                    {
                        File.AppendAllText(@"C:\log.txt", System.DateTime.Now.ToString() + " -> [ModuleManager] Disconnected Module: " + module.Name + " | " + module.Plugin.Name + Environment.NewLine);
                        Current.Delete(module);
                    }
                }
            }
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
            if (ModuleManager.Current.GetModule(module.Name) == null && module.Plugin != null)
            {
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