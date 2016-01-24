using PluginInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace EniacHome.ModuleManager
{
    public class Module
    {
        public string Name { get; set; }

        public Socket Socket { get; set; }

        public IPlugin Plugin { get; set; }
    }
}
