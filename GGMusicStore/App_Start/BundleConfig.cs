using System.Web;
using System.Web.Optimization;

namespace GGMusicStore
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery-{version}.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"/*,
                      "~/Content/site.css"*/));

            #region 模板
            bundles.Add(new ScriptBundle("~/bundles/Scripts/template").Include(
                                  "~/Scripts/template/custom.js",
                                  "~/Scripts/template/template.js"));
            bundles.Add(new StyleBundle("~/Content/Styles/template").Include(
                                  "~/Content/template/animate.css",
                                  "~/Content/template/animations.css",
                                  "~/Content/template/custom.css",
                                  "~/Content/template/style.css"));
            bundles.Add(new StyleBundle("~/Content/Styles/font-awesome").Include(
                                   "~/Content/font-awesome.css"));


            #endregion

            #region 插件

            //轮播插件
            bundles.Add(new StyleBundle("~/Content/Styles/unslider").Include(
             "~/Content/unslider.css",
             "~/Content/unslider-dots.css"));
            bundles.Add(new ScriptBundle("~/bundles/Scripts/unslider").Include(
                     "~/Scripts/unslider.js"));

            //筛选插件
            bundles.Add(new ScriptBundle("~/bundles/Scripts/isotope").Include(
                     "~/Scripts/plugins/isotope/isotope.pkgd.js"));

            //动态背景
            bundles.Add(new ScriptBundle("~/bundles/Scripts/backstretch").Include(
                         "~/Scripts/plugins/jquery.backstretch.min.js"));

            //当元素滚动到窗口或变为可见
            bundles.Add(new ScriptBundle("~/bundles/Scripts/appear").Include(
                         "~/Scripts/plugins/jquery.appear.js"));

            //模态窗
            bundles.Add(new ScriptBundle("~/bundles/Scripts/layer").Include(
                         "~/Scripts/plugins/layer/layer.js"));
            bundles.Add(new StyleBundle("~/Content/Styles/layer").Include(
                        "~/Scripts/plugins/layer/skin/layer.css"));

            #endregion
        }
    }
}
