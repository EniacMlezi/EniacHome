﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginInterface;
using System.Reflection;

namespace MVC_default.Plugins.TemperatureModule
{
    public class TemperatureModule : IPlugin
    {
        public string Title
        {
            get { return "Temperature"; }
        }
        public string Name
        {
            get { return Assembly.GetAssembly(GetType()).GetName().Name; }
        }

        public string Author
        {
            get { return "Lars Gardien"; }
        }
        public Version Version
        {
            get { return new Version(1, 0, 0, 0); }
        }
        public string EntryAreaName
        {
            get { return "Temperature"; }
        }

        public string WidgetWidth
        {
            get { return "4"; }
        }
    }
}