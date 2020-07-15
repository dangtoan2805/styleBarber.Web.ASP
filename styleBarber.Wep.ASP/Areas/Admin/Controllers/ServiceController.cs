using styleBarber.Wep.ASP.Areas.Admin.Models;
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
        private ServiceModel _model = new ServiceModel();
        public ActionResult Services()
        {
           
            ViewBag.Services = _model.GetServices();
            return View();
        }
        public ActionResult TimKiem(string ten)
        {
    
            ViewBag.Services = _model.TimTen(ten);
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
            _model.ThemDV(service);
            return RedirectToAction("Services");
        }

        public ActionResult DeleteService(int ID)
        {
            _model.XoaDV(ID);
            return RedirectToAction("Services");
        }

        public ActionResult ServiceDetail(int ID)
        {
            return View(_model.XemDV(ID));
        }

        public ActionResult UpdateService(int ID, Service service)
        {
            _model.SuaDV(ID, service);
            return RedirectToAction("Services");
        }

    }
}