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
        private BarberContext _context = new BarberContext();
        public ActionResult Barbers()
        {
            var Barbers = _context.Barbers.ToList();
            ViewBag.Barbers = Barbers;
            return View();
        }

        [HttpGet]
        public ActionResult AddBarber()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBarber(Barber barber)
        {
            _context.Barbers.Add(new Barber { Name = barber.Name, Info = barber.Info, Email = barber.Email, LinkFB = barber.LinkFB });
            _context.SaveChanges();
            return RedirectToAction("Barbers");
        }

        public ActionResult DeleteBarber(int ID)
        {
            var bar = _context.Barbers.Find(ID);

            _context.Barbers.Remove(bar);
            _context.SaveChanges();
            return RedirectToAction("Barbers");
        }

        public ActionResult BarberDetail(int ID)
        {
            var bar = _context.Barbers.Find(ID);
         
            return View(bar);
        }

        public ActionResult UpdateBarber(int ID,Barber barber)
        {
            var bar = _context.Barbers.Find(ID);
            bar.Name = barber.Name;
            bar.LinkFB = barber.LinkFB;
            _context.SaveChanges();
            return RedirectToAction("Barbers");
        }



    }
}