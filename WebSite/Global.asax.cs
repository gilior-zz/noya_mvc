using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using StackExchange.Profiling;
using StackExchange.Profiling.EntityFramework6;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace WebSite
{
    public enum Lang
    {
        Heb, Eng
    }
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
            //MiniProfilerEF6.Initialize();

            //MiniProfiler.Settings.Results_List_Authorize = (i) => { return true; };
        }
        protected void Session_Start()
        {
            var v = Server.MapPath("~/config.xml");
            var vv = File.ReadAllText(v);
            XDocument doc = XDocument.Load(v);
         
            var vvv = doc.Descendants("image");
            vvv.Remove();
        }
        //protected void Application_BeginRequest()
        //{
        //    if (Request.IsLocal)
        //    {
        //        MiniProfiler.Start();
        //    }
        //}
        //protected void Application_EndRequest()
        //{
        //    MiniProfiler.Stop();
        //}


    }
}
