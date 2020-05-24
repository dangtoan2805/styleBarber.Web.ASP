using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Controllers
{
    public class ServiceController : Controller
    {
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Barbers()
        {
            return View();
        }
        public ActionResult Appointment()
        {
            return View();
        }
        public ActionResult Services()
        {
            return View();
        }
    }
}