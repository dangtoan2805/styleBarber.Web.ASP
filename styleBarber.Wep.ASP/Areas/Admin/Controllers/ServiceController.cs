using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
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
        // GET: Admin/Barber
        private BarberContext _context = new BarberContext();
        public ActionResult Services()
        {
            var Services = _context.Services.ToList();
            ViewBag.Services = Services;
            return View();
        }
        public ActionResult TimKiem(string ten)
        {
            var list = _context.Services.Where(c => c.Name == ten).ToList();
            ViewBag.Services = list;
            return View("Services");
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(Service service)
        {
            _context.Services.Add(new Service { Name = service.Name, ServiceDescription = service.ServiceDescription, Price = service.Price });
            _context.SaveChanges();
            return RedirectToAction("Services");
        }

        public ActionResult DeleteService(int ID)
        {
            var ser = _context.Services.Find(ID);

            _context.Services.Remove(ser);
            _context.SaveChanges();
            return RedirectToAction("Services");
        }

        public ActionResult ServiceDetail(int ID)
        {
            var ser = _context.Services.Find(ID);

            return View(ser);
        }

        public ActionResult UpdateService(int ID, Service service)
        {
            var ser = _context.Services.Find(ID);
            ser.Name = service.Name;
            ser.ServiceDescription = service.ServiceDescription;
            ser.Price = service.Price;
           
            _context.SaveChanges();
            return RedirectToAction("Services");
        }

    }
}