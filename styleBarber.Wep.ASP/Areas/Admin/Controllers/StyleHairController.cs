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
    public class StyleHairController : Controller
    {
        // GET: Admin/Service
        // GET: Admin/Barber
        private StyleHairModel _model = new StyleHairModel();
        public ActionResult StyleHairs()
        {
            ViewBag.StyleHair = _model.GetStyleHairs();
            return View();
        }
        public ActionResult TimKiem(string ten)
        {
            ViewBag.StyleHair = _model.TimTen(ten);
            return View("StyleHairs");
        }

        [HttpGet]
        public ActionResult AddStyleHair()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStyleHair(StyleHair stylehair)
        {
            _model.ThemKT(stylehair);
            return RedirectToAction("StyleHairs");
        }

        public ActionResult DeleteStyleHair(int ID)
        {
            _model.XoaKT(ID);
            return RedirectToAction("StyleHairs");
        }

        public ActionResult StyleHairDetail(int ID)
        {         
            return View(_model.XemKT(ID));
        }

        public ActionResult UpdateStyleHair(int ID, StyleHair stylehair)
        {
            _model.SuaKT(ID, stylehair);
            return RedirectToAction("StyleHairs");
        }

    }
}