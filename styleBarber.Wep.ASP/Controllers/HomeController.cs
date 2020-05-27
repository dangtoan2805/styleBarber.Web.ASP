using styleBarber.Wep.ASP.EF;
using styleBarber.Wep.ASP.Entities;
using styleBarber.Wep.ASP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Controllers
{
    public class HomeController : Controller
    {
        private BarberContext _context = new BarberContext();
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {

            

            return View();
        }
        [HttpPost]
        public ActionResult SendContact(ContactVM vM)

        {
            _context.Contacts.Add(new Contact { FirstName = vM.FirstName, LastName = vM.LastName , Email = vM.Email, Phone = vM.Phone, Note = vM.Note}) ;
            return View();
        }
    }
}