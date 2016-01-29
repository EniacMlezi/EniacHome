using ModuleFinderInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Compilation;
using System.Web.Hosting;

namespace EniacHome.ModuleFinderManager
{
    public class ModuleFinderInitiator
    {
        static ModuleFinderInitiator()
        {
            string moduleFindersPath = HostingEnvironment.MapPath("~/plugins");
            string moduleFindersTempPath = HostingEnvironment.MapPath("~/plugins/temp");

            if (moduleFindersPath == null || moduleFindersTempPath == null)
                throw new DirectoryNotFoundException("plugins");

            ModuleFinderFolder = new DirectoryInfo(moduleFindersPath);
            TempModuleFinderFolder = new DirectoryInfo(moduleFindersTempPath);
        }

        /// <summary>
        /// The source plugin folder from which to copy from
        /// </summary>
        /// <remarks>
        /// This folder can contain sub folders to organize plugin types
        /// </remarks>
        private static readonly DirectoryInfo ModuleFinderFolder;

        /// <summary>
        /// The folder to  copy the plugin DLLs to use for running the app
        /// </summary>
        private static readonly DirectoryInfo TempModuleFinderFolder;

        /// <summary>
        /// Initialize method that registers all plugins
        /// </summary>
        public static void InitializeModuleFinders()
        {
            Directory.CreateDirectory(TempModuleFinderFolder.FullName);

            //clear out plugins
            foreach (var f in TempModuleFinderFolder.GetFiles("*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    f.Delete();
                }
                catch (Exception)
                {

                }

            }

            //copy files
            foreach (var plug in ModuleFinderFolder.GetFiles("*.dll", SearchOption.AllDirectories))
            {
                try
                {
                    var di = Directory.CreateDirectory(TempModuleFinderFolder.FullName);
                    File.Copy(plug.FullName, Path.Combine(di.FullName, plug.Name), true);
                }
                catch (Exception)
                {

                }
            }
            
            var assemblies = TempModuleFinderFolder.GetFiles("*.dll", SearchOption.AllDirectories)
                    .Select(x => AssemblyName.GetAssemblyName(x.FullName))
                    .Select(x => Assembly.Load(x.FullName));

            foreach (var assembly in assemblies)
            {
                Type type = assembly.GetTypes().Where(t => typeof(IModuleFinder).IsAssignableFrom(t)).FirstOrDefault();
                if (type != null)
                {
                    //Add the finders to the manager to manage them later
                    var ModuleFinder = (IModuleFinder)Activator.CreateInstance(type);
                    ModuleFinderManager.Current.ModuleFinders.Add(ModuleFinder);
                }
            }
        }
    }
}
