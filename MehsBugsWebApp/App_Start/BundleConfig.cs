using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MehsBugsWebApp
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        public static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/jquery-ui-1.12.1.js",
                "~/Scripts/jquery.blockUI.js",
                "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                "~/Scripts/toastr.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery.backstretch.js",
                      "~/Scripts/fader.min.js",
                      "~/Scripts/string-builder.js"));

            bundles.Add(new ScriptBundle("~/bundles/mehs").Include(
                    "~/Scripts/mehs-model.js",
                     "~/Scripts/mehs-core.js"));

            bundles.Add(new ScriptBundle("~/bundles/tipuesearch").Include(
                    "~/Scripts/tipuesearch*"
                ));
            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                    "~/Scripts/mehs-menu.js"
                ));
        }

        public static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/toastr.css",
                "~/Content/Site.css",
                "~/Content/fader.min.css",
                "~/Content/default-style.css"));

            bundles.Add(new StyleBundle("~/bundles/defaultCss").Include(

                ));

            bundles.Add(new StyleBundle("~/bundles/homeCss").Include(
                "~/Content/bootstrap.css",
                "~/Content/font-awesome.css",
                "~/Content/toastr.css",
                "~/Content/fader.min.css",
                "~/Content/home-style.css"
                ));
        }
    }
}