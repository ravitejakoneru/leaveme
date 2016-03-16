using System.Web;
using System.Web.Optimization;

namespace LeaveMe
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/jquery-ui-1.9.2.custom.min.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/dataTables.bootstrap.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/metisMenu.js",
                       "~/Scripts/menu.js",
                       "~/Scripts/select2.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/admin").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/jqueryui/jquery-ui-1.10.0.custom.css",
                     "~/Content/datepicker/bootstrap-datepicker.css",
                     "~/Content/metisMenu.css",
                     "~/Content/dataTables.bootstrap.css",
                     "~/Content/admin.css",
                     "~/Content/font-awesome.css",
                     "~/Content/Select2.css"
                     ));
        }
    }
}
