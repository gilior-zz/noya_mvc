using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Helpers
{
    public class CultureController : Controller
    {

        public ActionResult SetCulture(string culture, string url)
        {
            // Validate input
            //culture = CultureHelper.GetImplementedCulture(culture);
            //string last = url.Split('/').Last();
            //bool home = last.Contains('-');
            //RouteData.Values.Clear();
            //RouteData.Values["culture"] = culture;  // set culture
            //RouteData.Values["controller"] = home ? string.Empty : last;


            //return RedirectToAction("Index", RouteData.Values["controller"].ToString());
            culture = CultureHelper.GetImplementedCulture(culture);
            // Save culture in a cookie
            HttpCookie cookie = Request.Cookies["_culture"];
            if (cookie != null)
                cookie.Value = culture;   // update cookie value
            else
            {
                cookie = new HttpCookie("_culture");
                cookie.Value = culture;
                //cookie.Expires = DateTime.Now.AddYears(1);
            }
            Response.Cookies.Add(cookie);

            return Redirect(url);

        }
    }
}