using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Controllers
{
    public class ServiceController : Controller
    {
        private ServiceModel _model = new ServiceModel();
    
        public ActionResult Appointment()
        {
            // *********Show List Time ********//
            return View(new AppointmentVM());
        }
        public ActionResult Barbers()
        {
            //GET: Barbers           
            ViewBag.Barbers = _model.GetAllBarbers();


            return View();
        }
        public ActionResult Services()
        {
            //GET: Service
          
            ViewBag.Services = _model.GetAllServices();
            return View();
        }

        public ActionResult SendAppointment(AppointmentVM appointmentVM)
        {
            if (ModelState.IsValid)
            {

            }
            return View("Appointment", appointmentVM);
        }

    }
}