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
        private HomeModel _model = new HomeModel();

        public ActionResult Index()
        {
            //GET INFO
            var Info = _model.info();
            ViewBag.About = Info.About;
            ViewBag.Mission = Info.Mission;
            ViewBag.Reason = Info.Reason;
            //GET STYLE HAIR          
            ViewBag.StyleHair = _model.GetStyleHairs();
            // GET SERVICES
            ViewBag.Services = _model.GetServices();
            //GET BARBERS
            ViewBag.Barbers = _model.GetBarbers();
            //GET REIVIERS
            ViewBag.Reviewer = _model.GetReviewers();
            return View();
        }

        public ActionResult About()
        {
            //GET INFO
            var Info = _model.info();
            ViewBag.About = Info.About;
            ViewBag.Mission = Info.Mission;
            ViewBag.Reason = Info.Reason;
            //GET STYLE HAIR
            ViewBag.StyleHair = _model.GetStyleHairs();
            //GET REIVIEWER
            ViewBag.Reviewer = _model.GetReviewers();
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