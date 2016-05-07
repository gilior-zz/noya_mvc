using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Helpers
{
    public static class DBHelper
    {
        public static WebDBEntities DB
        {
            get
            {
                var obj = HttpContext.Current.Application.Get("WebDBEntities") as WebDBEntities;
                return obj;
            }

        }

    }
}