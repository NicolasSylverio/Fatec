using System.Web.Optimization;

namespace Fatec.Mvc
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                            "~/Scripts/materialize.min.js",
                            "~/Scripts/service-worker.js",
                            "~/Scripts/site.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                            "~/Content/css/site.css",
                            "~/Content/css/materialize.min.css",
                            "~/Content/css/material-icons.css"));
        }
    }
}