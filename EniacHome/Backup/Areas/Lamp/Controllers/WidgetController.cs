using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using EniacHome.ModuleManager;
using EniacHome.Plugins.LampPlugin.Models;
using System.Net.Sockets;

namespace EniacHome.Plugins.LampPlugin.Controllers
{
    public class WidgetController : Controller
    {
        public ActionResult Index(string id)
        {
            Module module =  ModuleManager.ModuleManager.Current.GetModule(id);
            Socket handler = module.Socket;

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
            catch
            {
                // Error connecting
            }

            return View(new WidgetViewModel { value = value });
        }
    }
}
