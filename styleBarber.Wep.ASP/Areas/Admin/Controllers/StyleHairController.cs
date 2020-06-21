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
        private BarberContext _context = new BarberContext();
        public ActionResult StyleHairs()
        {
            var StyleHair = _context.StyleHair.ToList();
            ViewBag.StyleHair = StyleHair;
            return View();
        }
        public ActionResult TimKiem(string ten)
        {
            var list = _context.StyleHair.Where(c => c.Title == ten).ToList();
            ViewBag.StyleHair = list;
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
            _context.StyleHair.Add(new StyleHair { Title = stylehair.Title, StyleDescription = stylehair.StyleDescription});
            _context.SaveChanges();
            return RedirectToAction("StyleHairs");
        }

        public ActionResult DeleteStyleHair(int ID)
        {
            var sty = _context.StyleHair.Find(ID);

            _context.StyleHair.Remove(sty);
            _context.SaveChanges();
            return RedirectToAction("StyleHairs");
        }

        public ActionResult StyleHairDetail(int ID)
        {
            var sty = _context.StyleHair.Find(ID);

            return View(sty);
        }

        public ActionResult UpdateStyleHair(int ID, StyleHair stylehair)
        {
            var sty = _context.StyleHair.Find(ID);
            sty.Title = stylehair.Title;
            sty.StyleDescription = stylehair.StyleDescription;
   

            _context.SaveChanges();
            return RedirectToAction("StyleHairs");
        }

    }
}