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

        private BarberModel _barberModel = null;
        private StyleHairModel _stylerModel = null;
        private ServiceModel _serviceModel = null;
        private SettingModel _settingModel = null;
        private ContactModel _contactModel = null;
        public HomeController()
        {
            _barberModel = new BarberModel();
            _stylerModel = new StyleHairModel();
            _serviceModel = new ServiceModel();
            _settingModel = new SettingModel();
            _contactModel = new ContactModel();
        }
        public ActionResult Index()
        {
            // GET INFO
            var Info = _settingModel.GetInfo();
            ViewBag.About = Info.About;
            ViewBag.Mission = Info.Mission;
            ViewBag.Reason = Info.Reason;
            // GET STYLE HAIR
            ViewBag.StyleHair = _stylerModel.GetStyleHairVMs();
            // GET SERVICES
            ViewBag.Services = _serviceModel.GetServiceVMs();
            // GET BARBERS
            ViewBag.Barbers = _barberModel.GetBarberVMs();
            // GET REIVIERS
            ViewBag.Reviewer = _settingModel.GetReviewers();
            return View();
        }

        public ActionResult About()
        {
           
            ViewBag.StyleHair = new List<StyleHair>();
            ViewBag.Reviewer = new List<Reviewer>();
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SendContact(ContactVM contact)
        {
            _contactModel.Add(contact);
            return RedirectToAction("Thank", "Home");
        }

        public ActionResult Thank()
        {
            return View();
        }

       
    }
}