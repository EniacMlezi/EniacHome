using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EniacHome.ModuleManager;
using EniacHome.Plugins.LampPlugin.Models;
using System.Net.Sockets;
using ModuleInterface;
using TcpModuleFinder;

namespace EniacHome.Plugins.LampPlugin.Controllers
{
    public class WidgetController : Controller
    {
        public ActionResult Index(string id)
        {
            TcpModule module =  ModuleManager.ModuleManager.Current.GetModule(id) as TcpModule;
            Socket handler = module.socket;

            string value = "";
            byte[] message = Encoding.ASCII.GetBytes("get<EOF>");
            byte[] bytes = new byte[256];
            try
            {
                handler.Send(message, message.Length, SocketFlags.None);
                int received = handler.Receive(bytes, handler.Available, SocketFlags.None);
                if (received > 0)
                {
                    value = Encoding.ASCII.GetString(bytes);
                }
            }
            catch(Exception ex)
            {
                value = ex.ToString();
            }

            ViewBag.Received = "value: " + value;
            return View();
        }
    }
}
