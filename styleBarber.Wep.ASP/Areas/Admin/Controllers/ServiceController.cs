using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Admin/Service
        public ActionResult Services()
        {
            return View();
        }

        public ActionResult ServiceDetail()
        {
            return View();
        }
    }
}