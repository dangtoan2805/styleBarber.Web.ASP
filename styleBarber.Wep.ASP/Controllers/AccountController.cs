using styleBarber.Wep.ASP.Entities;
using styleBarber.Wep.ASP.Helper;
using styleBarber.Wep.ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;

namespace styleBarber.Wep.ASP.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        private UserModel _userModel = null;
        private static string _url = null;
        public AccountController()
        {
            _userModel = new UserModel();
        }
        public ActionResult Index(string url=null)
        {
           _url = url;
            return View();
        }

        public ActionResult Login(string email, string password)
        {
            string controller = "Home";
            string action = "Index";
            if (_url != null) {
                string[] req = _url.Split('/');
                controller = req[1];
                action = req[2];
            }
            _userModel.UserLogin(email, password);
            switch (_userModel.UserLogin(email, password))
            {
                case 0:
                    return RedirectToRoute(new { area = "Admin", controller = "Home" });
                case 1:
                    return RedirectToAction(action, controller);
                default:
                    return RedirectToAction("Index");
            }
        }

        public ActionResult Register()
        {
            return View(new UserVM());
        }


        [HttpPost]
        public ActionResult Register(UserVM user, string password, string re_password, HttpPostedFileBase File)
        {
            if (password != re_password)
                return View("Register", user);
            user.Image = Helpful.UploadImage(File, Server);
            _userModel.AddUser(user,password);
            return RedirectToAction("Index","Account");
        }

        public ActionResult Logout()
        {
            _userModel.UserLogout();
            return RedirectToAction("Index", "Home");
        }
    }
}