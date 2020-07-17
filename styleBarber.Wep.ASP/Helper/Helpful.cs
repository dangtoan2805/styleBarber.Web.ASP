using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace styleBarber.Wep.ASP.Helper
{
    public static class Helpful
    {
        public static string UploadImage(HttpPostedFileBase file, HttpServerUtilityBase server)
        {
            string img = "no-img.jpg";
            if (file != null)
            {
                img = file.FileName;
                var path = Path.Combine(server.MapPath("~/Upload"), img);
                file.SaveAs(path);
            }
            return img;
        }
    }
}