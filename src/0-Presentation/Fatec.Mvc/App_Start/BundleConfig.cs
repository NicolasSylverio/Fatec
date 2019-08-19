using System.Web.Optimization;

namespace Fatec.Mvc
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                      "~/Scripts/materialize.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize.min.css",
                      "~/Content/site.css",
                      "~/Content/material-icons.css"));
        }
    }
}