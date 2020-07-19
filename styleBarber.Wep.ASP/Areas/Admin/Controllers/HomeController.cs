using styleBarber.Wep.ASP.Models;
using System;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    //Admin
    [Authorize]

    public class HomeController : Controller
    {
        private AppoimentModel _appointmentModel = null;
        public HomeController()
        {
            _appointmentModel = new AppoimentModel();
        }
        public ActionResult Index()
        {
            ViewBag.Total = _appointmentModel.CountTotal();
            return View();
        }

        public JsonResult GetAppoitmentByDate(string start, string end)
        {
            DateTime dStart = Convert.ToDateTime(start);
            DateTime dEnd = Convert.ToDateTime(end);
            var data = _appointmentModel.FilterByDate(dStart, dEnd);
            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTopBarber()
        {
            return Json(_appointmentModel.GetTopBarber(), JsonRequestBehavior.AllowGet);
        }

        public void UpdateStatus(int id, bool status)
        {
            _appointmentModel.Update(id, status);
        }
    }
}