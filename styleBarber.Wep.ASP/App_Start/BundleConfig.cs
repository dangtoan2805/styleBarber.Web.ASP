using System.Web;
using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace styleBarber.Wep.ASP
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            //*************User***************//
            bundles.Add(new ScriptBundle("~/bundles/jquery-1").Include("~/Scripts/jquery-1.12.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap-4.1").Include("~/Scripts/bootstrap-4.1.1.min.js.map"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                "~/Scripts/main.js",
                "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/style.css",
                "~/Content/versions.css",
                "~/Content/responsive.css"));
            bundles.Add(new ScriptBundle("~/bundles/map").Include("~/Scripts/map.js"));
            //*************Admin***************//
            //Ref font style css
            bundles.Add(new StyleBundle("~/Content/Admin/font-css").Include(
                "~/Content/font-face.css",
                "~/Content/fontawesome-all.min.css",
                "~/Content/font-awesome.min.css",
                "~/Content/material-design-iconic-font.min.css"
                ));
            //Bootstrap 4.1
            bundles.Add(new StyleBundle("~/Content/Admin/bootstrap").Include("~/Content/bootstrap.min.css"));
            //Vendor
            bundles.Add(new StyleBundle("~/Content/Admin/vendor").Include(
                "~/Content/animsition.min.css",
                "~/Content/bootstrap-progressbar-3.3.4.min.css",
                "~/Content/animate-wow.css",
                "~/Content/hamburgers.min.css",
                "~/Content/slick.css",
                "~/Content/select2.min.css",
                "~/Content/perfect-scrollbar.css",
                "~/Content/theme.css"
                ));
            //Jquery 3 JS
            bundles.Add(new ScriptBundle("~/bundles/jquery-3").Include("~/Scripts/jquery-3.4.1.min.js"));
            //Bootstrap JS
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-popper").Include("~/Scripts/popper.min.js"));
            //Vendro JS
            bundles.Add(new ScriptBundle("~/bundles/vendor").Include(
                "~/Scripts/slick.min.js",
                "~/Scripts/wow.min.js",
                "~/Scripts/animsition.min.js",
                "~/Scripts/bootstrap-progressbar.min.js",
                "~/Scripts/jquery.waypoints.min.js",
                "~/Scripts/jquery.counterup.min.js",
                "~/Scripts/circle-progress.min.js",
                "~/Scripts/perfect-scrollbar.min.js",
                "~/Scripts/Chart.bundle.min.js",
                "~/Scripts/select2.min.js",
                "~/Scripts/main-admin.js"
                ));

            

        }

    }
}
