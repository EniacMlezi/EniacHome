using System;

namespace PluginInterface
{ 
    public interface IPlugin
    {
        /// <summary>
        /// Title of the plugin, can be used as a property to display on the user interface
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Name of the plugin, should be an unique name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Author of the plugin
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Version of the loaded plugin
        /// </summary>
        Version Version { get; }

        /// <summary>
        /// Entry area name
        /// </summary>
        string EntryAreaName { get; }

        /// <summary>
        /// Width for the widget
        /// </summary>
        string WidgetWidth { get; }

        /// <summary>
        /// Height for the widget
        /// </summary>
        string WidgetHeight { get; }



    }
}
