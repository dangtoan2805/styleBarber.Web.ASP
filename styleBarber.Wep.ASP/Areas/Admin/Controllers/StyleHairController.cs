using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace styleBarber.Wep.ASP.Areas.Admin.Controllers
{
    public class StyleHairController : Controller
    {
        // GET: Admin/StyleHair
        public ActionResult StyleHairs()
        {
            return View();
        }

        public ActionResult StyleHairDetail()
        {
            return View();
        }
    }
}