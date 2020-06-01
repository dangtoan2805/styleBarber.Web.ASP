using Microsoft.Ajax.Utilities;
using Newtonsoft.Json.Linq;
using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using styleBarber.Wep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Controllers
{
    public class HomeController : Controller
    {
        private BarberContext _context = new BarberContext();

        public ActionResult Index()
        {
            //GET INFO
            var Info = _context.InfoStores.ToList();
            ViewBag.About = Info[0].About;
            ViewBag.Mission = Info[0].Mission;
            ViewBag.Reason = Info[0].Reason;
            //GET STYLE HAIR
            var StyleHair = _context.StyleHair.Take(3).ToList();
            ViewBag.StyleHair = StyleHair;
            // GET SERVICES
            var Services = _context.Services.Take(3).ToList();
            ViewBag.Services = Services;
            //GET BARBERS
            var Barbers = _context.Barbers.Take(3).ToList();
            ViewBag.Barbers = Barbers;
            //GET REIVIERS
            var list = _context.Reviewers.ToList();
            ViewBag.Reviewer = list;
            return View();
        }

        public ActionResult About()
        {
            //GET INFO
            var Info = _context.InfoStores.ToList();
            ViewBag.About = Info[0].About;
            ViewBag.Mission = Info[0].Mission;
            ViewBag.Reason = Info[0].Reason;
            //GET STYLE HAIR
            var StyleHair = _context.StyleHair.Take(3).ToList();
            ViewBag.StyleHair = StyleHair;
            //GET REIVIEWER
            var list = _context.Reviewers.ToList();
            ViewBag.Reviewer = list;
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SendContact(ContactVM contact)
        {
            return View();
        }


       
    }
}