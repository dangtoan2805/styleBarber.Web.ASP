using styleBarber.Wep.ASP.Helper;
using styleBarber.Wep.ASP.Models;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    public class BarberController : Controller
    {
        private BarberModel _barberModel = null;
        public BarberController()
        {
            _barberModel = new BarberModel();
        }
        public ActionResult Barbers()
        {
            ViewBag.Barbers = _barberModel.GetBarberVMs();
            return View();
        }
        public ActionResult TimKiem(string ten)
        {  
            ViewBag.Barbers = _barberModel.Find(ten);
            return View("Barbers");
        }
        public ActionResult Filter(int level)
        {
            if (level < 2)
                ViewBag.Barbers = _barberModel.Filter(level == 1);
            return View("Barbers");
        }

        [HttpGet]
        public ActionResult AddBarber()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddBarber(BarberVM barber, HttpPostedFileBase Image)
        {
            barber.Image = Helpful.UploadImage(Image, Server);
            _barberModel.AddBarber(barber);
            return RedirectToAction("Barbers");
        }

        public ActionResult DeleteBarber(int ID)
        {
            _barberModel.Delete(ID);
            return RedirectToAction("Barbers");
        }

        public ActionResult BarberDetail(int ID)
        {
            return View(_barberModel.Detail(ID));
        }

        public ActionResult UpdateBarber(int ID, BarberVM barber, HttpPostedFileBase Image)
        {
            barber.Image = Helpful.UploadImage(Image, Server);
            _barberModel.Update(ID, barber);
            return RedirectToAction("Barbers");
        }

    }
}