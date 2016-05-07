using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class EventItem
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public string Data { get; set; }

        public bool HasNext { get; set; }
        public bool HasPrev { get; set; }

    }
}