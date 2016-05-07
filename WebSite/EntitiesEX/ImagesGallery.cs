using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class ImagesGallery
    {
        public ImagesGallery()
        {
            ImageDescription = string.Empty;
            Visible = true;
            ImagePath = string.Empty;
            TimeStamp = DateTime.Now;
            Order = 0;
        }
    }
}