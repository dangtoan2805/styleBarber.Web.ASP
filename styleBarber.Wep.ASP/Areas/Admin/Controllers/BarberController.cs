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
    public class BarberController : Controller
    {
        // GET: Admin/Barber

        private BarberModel _model = new BarberModel();
        public ActionResult Barbers()
        {
            ViewBag.Barbers = _model.GetListBarbers();
            return View();
        }
        public ActionResult TimKiem(string ten)
        {
      
            ViewBag.Barbers = _model.TimTen(ten);
            return View("Barbers");
        }
        public ActionResult Filter(int level)
        {
           
            ViewBag.Barbers = _model.Filters(level);
            return View("Barbers");
        }

        [HttpGet]
        public ActionResult AddBarber()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBarber(Barber barber)
        {
            _model.ThemNV(barber);
            return RedirectToAction("Barbers");
        }

        public ActionResult DeleteBarber(int ID)
        {
            _model.XoaNV(ID);
            return RedirectToAction("Barbers");
        }

        public ActionResult BarberDetail(int ID)
        {
          
            return View(_model.XemNV(ID));
        }

        public ActionResult UpdateBarber(int ID, Barber barber)
        {
            _model.SuaNV(ID, barber);
            return RedirectToAction("Barbers");
        }

    }
}