using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MVC_default.Plugins;
using MVC_default.ModuleManager;
using System.Net.Sockets;

namespace MVC_default.Plugins.LampPlugin.Controllers
{
    public class WidgetController : Controller
    {
        public ActionResult Index(string id)
        {
            Module module =  ModuleManager.ModuleManager.Current.GetModule(id);
            Socket handler = module.Socket;

            string value = "";
            byte[] message = Encoding.ASCII.GetBytes("GET<EOF>");
            byte[] bytes = new byte[256];
            try
            {
                handler.Connect(handler.RemoteEndPoint);

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


            ViewBag.Received = value;

            return View();
        }
    }
}
