using styleBarber.Wep.ASP.Entities;
using styleBarber.Wep.ASP.Helper;
using styleBarber.Wep.ASP.Models;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    //Admin
    public class SettingController : Controller
    {
        private SettingModel _settingModel = null;

        public SettingController()
        {
            _settingModel = new SettingModel();
        }
        public ActionResult Index()
        {
            return View(_settingModel.GetInfo());
        }

        public ActionResult Update(InfoStore info, HttpPostedFileBase file)
        {
            info.Logo = Helpful.UploadImage(file, Server);
            _settingModel.UpdateInfo(info);
            return RedirectToAction("Index", "Home");
        }
    }
}