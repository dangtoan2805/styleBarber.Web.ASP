using styleBarber.Wep.ASP.Helper;
using styleBarber.Wep.ASP.Models;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    public class StyleHairController : Controller
    {
        // GET: Admin/Service
        private StyleHairModel _styleModel = null;
        public StyleHairController()
        {
            _styleModel = new StyleHairModel();
        }
        public ActionResult StyleHairs()
        {

            ViewBag.StyleHair = _styleModel.GetStyleHairVMs();
            return View();
        }
        public ActionResult TimKiem(string ten)
        {

            ViewBag.StyleHair = _styleModel.Find(ten);
            return View("StyleHairs");
        }

        [HttpGet]
        public ActionResult AddStyleHair()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddStyleHair(StyleHairVM stylehair, HttpPostedFileBase file)
        {
            stylehair.Image = Helpful.UploadImage(file, Server);
            _styleModel.AddStyleHair(stylehair);
            return RedirectToAction("StyleHairs");
        }

        public ActionResult DeleteStyleHair(int ID)
        {
            _styleModel.Delete(ID);
            return RedirectToAction("StyleHairs");
        }

        public ActionResult StyleHairDetail(int ID)
        {
            return View(_styleModel.Detail(ID));
        }

        public ActionResult UpdateStyleHair(int ID, StyleHairVM stylehair , HttpPostedFileBase file)
        {
            stylehair.Image = Helpful.UploadImage(file, Server);
            _styleModel.Udpdate(ID, stylehair);
            return RedirectToAction("StyleHairs");
        }

    }
}