using styleBarber.Wep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        private ContactModel _contactModel = null;
        
        public ContactController()
        {
            _contactModel = new ContactModel();

        }

        public ActionResult Index()
        {
            return View(_contactModel.GetContactVMs());
        }
    }
}