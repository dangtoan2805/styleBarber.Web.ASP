using styleBarber.Wep.ASP.Models;
using System;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    //Admin
    public class HomeController : Controller
    {
        private AppoimentModel _appointmentModel = null;
        private ContactModel _contactModel = null;
        public HomeController()
        {
            _appointmentModel = new AppoimentModel();
            _contactModel = new ContactModel();
        }
        public ActionResult Index()
        {
            ViewBag.Total = _appointmentModel.CountTotal();
            return View();
        }

        public JsonResult GetAppoitmentByDate(string date)
        {
            var dateCr = Convert.ToDateTime(date).ToString();
            var data = _appointmentModel.FilterByDate(Convert.ToDateTime(date));
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetContacts()
        {
            return Json(_contactModel.GetContactVMs());
        }
    }
}