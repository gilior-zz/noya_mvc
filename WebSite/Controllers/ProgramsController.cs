using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace WebSite
{
    public class ProgramsController : BaseController
    {
        private WebDBEntities db = new WebDBEntities();
        //
        // GET: /Programs/
        public ActionResult Index()
        {

            bool dir = CultureHelper.IsRighToLeft();
            StringBuilder sb = new StringBuilder();
            switch (dir)
            {
                case true:
                    foreach (var item in db.Programs.OrderBy(i => i.Order))
                        sb.Append(item.Heb).Append("<div class='col-xs-12 col-sm-12 col-md-12 col-lg-12'><hr/></div>");

                    break;
                case false:
                    foreach (var item in db.Programs.OrderBy(i => i.Order))
                        sb.Append(item.Eng).Append("<div class='col-xs-12 col-sm-12 col-md-12 col-lg-12'><hr/></div>");
                    break;
            }

            return View(model: sb.ToString());
        }
    }

}