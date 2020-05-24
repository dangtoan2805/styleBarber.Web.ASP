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

            bundles.Add(new ScriptBundle("~/bundles/jquery-1").Include("~/Scripts/jquery-1.12.4.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap-4.1").Include("~/Scripts/bootstrap-4.1.1.min.js.map"));
            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                                        "~/Scripts/main.js",
                                        "~/Scripts/custom.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                                        "~/Content/bootstrap.min.css",
                                        "~/Content/style.css",
                                        "~/Content/versions.css",
                                        "~/Content/responsive.css",
                                        "~/Content/custom.css"));
            bundles.Add(new ScriptBundle("~/bundles/map").Include("~/Scripts/map.js"));

        }

    }
}
