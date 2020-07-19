using styleBarber.Wep.ASP.Entities;
using styleBarber.Wep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private UserModel _userModel = null;
        public HomeController()
        {
            _barberModel = new BarberModel();
            _stylerModel = new StyleHairModel();
            _serviceModel = new ServiceModel();
            _settingModel = new SettingModel();
            _contactModel = new ContactModel();
            _userModel = new UserModel();
        }
        public ActionResult Index()
        {
            // GET INFO
            var Info = _settingModel.GetInfo();
            ViewBag.About = Info.About;
            ViewBag.Mission = Info.Mission;
            ViewBag.Reason = Info.Reason;
            // GET STYLE HAIR
            ViewBag.StyleHair = _stylerModel.GetStyleHairVMs().Take(3);
            // GET SERVICES
            ViewBag.Services = _serviceModel.GetServiceVMs();
            // GET BARBERS
            ViewBag.Barbers = _barberModel.GetBarberVMs().Take(3);
            // GET REIVIERS
            ViewBag.Reviewer = _contactModel.GetContactVMs();
            return View();
        }

        public ActionResult About()
        {
           
            ViewBag.StyleHair = new List<StyleHair>();
            ViewBag.Reviewer = new List<ContactVM>();
            return View();
        }

        public ActionResult Contact()
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Account", new { url = HttpContext.Request.Path });
            string id = User.Identity.Name;
            ViewBag.User = _userModel.GetUser(Int32.Parse(id));
            return View();
        }


        public ActionResult SendContact(ContactVM contact)
        {
            if (!HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Contact");
            _contactModel.Add(contact);
            return RedirectToAction("Thank", "Home");
        }

        public ActionResult Thank()
        {
            return View();
        }

       
    }
}