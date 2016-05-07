using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite
{
    public class Picture
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}