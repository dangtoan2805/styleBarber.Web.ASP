using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    public class CTLICHController : Controller
    {
        // GET: Admin/Service
        // GET: Admin/Barber
        private BarberContext _context = new BarberContext();
        public ActionResult CTLICHS()
        {
            var Barbers = _context.Barbers.ToList();
            ViewBag.Barbers = Barbers;
            var Appointments = _context.Appointments.ToList();
            ViewBag.Appointments = Appointments;
            var AppointmentDetails = _context.AppointmentDetails.ToList();
            ViewBag.AppointmentDetails = AppointmentDetails;
            var Calendars = _context.Calendars.ToList();
            ViewBag.Calendars = Calendars;
            return View();
        }

        [HttpGet]
        public ActionResult AddCTLICH()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCTLICH(Barber barber, Calendar calendar,Appointment appointment , AppointmentDetail appointmentDetail)
        {
            
            _context.Calendars.Add(new Calendar { Time = calendar.Time });
            _context.Appointments.Add(new Appointment { Date = appointment.Date });
            _context.AppointmentDetails.Add(new AppointmentDetail { FisrtName = appointmentDetail.FisrtName, LastName = appointmentDetail.LastName, Phone = appointmentDetail.Phone });
            _context.Barbers.Add(new Barber { Name = barber.Name });
            _context.SaveChanges();
            return RedirectToAction("CTLICHS");
        }

        public ActionResult DeleteCTLICH(int ID)
        {
            var ctl = _context.Barbers.Find(ID);

            _context.Barbers.Remove(ctl);
            _context.SaveChanges();
            return RedirectToAction("CTLICHS");
        }

        public ActionResult CTLICHDetail(int ID, Barber barber, Calendar calendar, Appointment appointment, AppointmentDetail appointmentDetail)
        {
             var ca = _context.Calendars.Find(ID);
            var app = _context.Appointments.Find(ID);
            var apps = _context.AppointmentDetails.Find(ID);
            var bar = _context.Barbers.Find(ID);       

            return View(ca);
        }

        public ActionResult UpdateCTLICH(int ID, Barber barber, Calendar calendar, Appointment appointment, AppointmentDetail appointmentDetail)
        {
            var ca = _context.Calendars.Find(ID);
            var app = _context.Appointments.Find(ID);
            var apps = _context.AppointmentDetails.Find(ID);
            var bar = _context.Barbers.Find(ID);       
            ca.Time = calendar.Time;
            app.Date = appointment.Date;
            apps.FisrtName = appointmentDetail.FisrtName;
            apps.LastName = appointmentDetail.LastName;
            bar.Name = barber.Name;

            _context.SaveChanges();
            return RedirectToAction("CTLICHS");
        }

    }
}