using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite
{
    public class VideosController : BaseController
    {
        //
        // GET: /Videos/
        public ActionResult Index()
        {
            return View();
        }
	}
}