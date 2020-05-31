using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Models;
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
            var Barbers = _context.Barbers.Take(6).ToList();
            ViewBag.Barbers = Barbers;

            return View();
        }
        public ActionResult Services()
        {
            var Services = _context.Services.Take(6).ToList();
            ViewBag.Services = Services;
            return View();
        }

        public ActionResult SendAppointment(AppointmentVM appointmentVM)
        {

            return View();
        }

    }
}