using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_default.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrator, Moderator")]
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}