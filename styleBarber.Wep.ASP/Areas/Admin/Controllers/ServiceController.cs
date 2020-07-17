using styleBarber.Wep.ASP.Helper;
using styleBarber.Wep.ASP.Models;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    //ADMIN
    public class ServiceController : Controller
    {
        private ServiceModel _serviceModel = null;
        public ServiceController()
        {
            _serviceModel = new ServiceModel();
        }
        public ActionResult Services()
        {
            ViewBag.Services = _serviceModel.GetServiceVMs();
            return View();
        }
        public ActionResult TimKiem(string ten)
        {
            ViewBag.Services = _serviceModel.Find(ten);

            return View("Services");
        }
        [HttpGet]
        public ActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddService(ServiceVM service,HttpPostedFileBase file)
        {
            service.Image = Helpful.UploadImage(file, Server);
            _serviceModel.AddService(service);
            return RedirectToAction("Services");
        }

        public ActionResult DeleteService(int ID)
        {
            _serviceModel.Delete(ID);
            return RedirectToAction("Services");
        }

        public ActionResult ServiceDetail(int ID)
        {
            return View(_serviceModel.Detail(ID));
        }

        public ActionResult UpdateService(int ID, ServiceVM service, HttpPostedFileBase file)
        {
            service.Image = Helpful.UploadImage(file, Server);
            _serviceModel.Update(ID, service);
            return RedirectToAction("Services");
        }

    }
}