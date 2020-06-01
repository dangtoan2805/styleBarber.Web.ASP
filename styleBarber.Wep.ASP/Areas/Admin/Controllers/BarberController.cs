using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    public class BarberController : Controller
    {
        // GET: Admin/Barber
        public ActionResult Barbers()
        {
            return View();
        }

        public ActionResult BarberDetail()
        {
            return View();
        }
    }
}