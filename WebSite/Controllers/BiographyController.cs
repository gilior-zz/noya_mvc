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
    public class BiographyController : BaseController
    {
        private WebDBEntities db = new WebDBEntities();
        //
        // GET: /About/
        public ActionResult Index()
        {
           
            string cv =  CultureHelper.GetCurrentNeutralCulture();
            switch (cv)
            {
                case"he":
                    cv = db.CVs.FirstOrDefault().Heb;
                    break;
                case "en":
                    cv = db.CVs.FirstOrDefault().Eng;
                    break;
            }
            
            return View(model: cv);
        }
    }
}