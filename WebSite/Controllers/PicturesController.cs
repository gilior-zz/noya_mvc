using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Helpers;

namespace WebSite
{
    public class PicturesController : BaseController
    {
        private WebDBEntities db = new WebDBEntities();
        //
        // GET: /Pictures/
        public  ActionResult Index()
        {
            return View();
        }
	}
}