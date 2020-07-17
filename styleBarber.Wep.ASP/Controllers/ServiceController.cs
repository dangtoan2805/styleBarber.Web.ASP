using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Controllers
{
    public class ServiceController : Controller
    {
        private BarberModel _barberModel = null;
        private ServiceModel _serviceModel = null;
        private AppoimentModel _appoimentModel = null;

        public ServiceController()
        {
            _barberModel = new BarberModel();
            _appoimentModel = new AppoimentModel();
            _serviceModel = new ServiceModel();
        }
    
        public ActionResult Appointment()
        {
            ViewBag.Barber = _barberModel.GetBarberVMs();
            ViewBag.Times = _appoimentModel.GetTimes();
            return View(new AppointmentVM());
        }
        public ActionResult Barbers()
        {
            //GET: Barbers
            ViewBag.Barbers = _barberModel.GetBarberVMs();

            return View();
        }
        public ActionResult Services()
        {
            //GET: Service
            ViewBag.Services = _serviceModel.GetServiceVMs();
            return View();
        }

        public ActionResult SendAppointment(AppointmentVM appointmentVM, string Time)
        {
            _appoimentModel.Add(appointmentVM);
            return RedirectToAction("Thank", "Home");
        }

    }
}