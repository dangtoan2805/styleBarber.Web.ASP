using styleBarber.Wep.ASP.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Controllers
{
    public class ServiceController : Controller
    {
        private BarberContext _context = new BarberContext();
        // GET: Service
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult Barbers()
        {

            var data = _context.Barbers.OrderBy(b => b.ID).Take(10).ToList();
            ViewBag.Data = data;
            return View();
        }
        public ActionResult Services()
        {



            return View();
        }

    }
}