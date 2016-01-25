using System;
using PluginInterface;
using System.Reflection;

namespace EniacHome.Plugins.TemplatePlugin
{
    public class LampPlugin : IPlugin
    {
        public string Title
        {
            get { return "Lamp"; }
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
            get { return "Lamp"; }
        }

        public string WidgetWidth
        {
            get { return "6"; }
        }

        public string WidgetHeight
        {
            get { return "3"; }
        }
    }
}
