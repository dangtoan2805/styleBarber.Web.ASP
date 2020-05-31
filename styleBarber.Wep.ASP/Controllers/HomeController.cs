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
            var list = _context.Reviewers.ToList();
            ViewBag.Reviewer = list;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SendContact(ContactVM contact)
        {
            return View();
        }


       
    }
}