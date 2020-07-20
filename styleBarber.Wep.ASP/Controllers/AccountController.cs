using styleBarber.Wep.ASP.Helper;
using styleBarber.Wep.ASP.Models;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
                    return RedirectToRoute(new { area="Admin", controller ="Home", action="Index" });
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
            if(!ModelState.IsValid)
                return View("Register", user);
            if (password != re_password)
            {
                ModelState.AddModelError("PassCorrect", "Password or Re-Password not Correct");
                return View("Register", user);
            }
            if (_userModel.CheckEmail(user.Email))
            {
                ModelState.AddModelError("Exists", "Email exists");
                return View("Register", user);
            }
            user.Image = Helpful.UploadImage(File, Server);
            _userModel.AddUser(user,password);
            return RedirectToAction("Index","Account");
        }

        public ActionResult Logout()
        {
            _userModel.UserLogout();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePass()
        {
            _userModel.UserLogout();
            ViewBag.UserID= User.Identity.Name;
            return View();
        }

        [HttpPost]
        public ActionResult ChangePass(string id,string pass, string re_pass)
        {
            if (pass != re_pass) 
            {
                ModelState.AddModelError("PassCorrect", "Password or Re-Password not Correct");
                return View("ChangePass");
            }
            _userModel.ChangePassword(Int32.Parse(id),pass);
            _userModel.UserLogout();
            return RedirectToAction("Index", "Home");
        }
    }
}