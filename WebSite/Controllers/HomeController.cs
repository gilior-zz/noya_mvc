using Helpers;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mail;
using System.Web.Mvc;
using WebSite;
using WebSite.Models;

namespace WebSite
{
    public class HomeController : BaseController
    {
        private WebDBEntities db = new WebDBEntities();
        //MiniProfiler profiler = MiniProfiler.Current; // it's ok if this is null

        //List<CalendarEvent> db.CalendarEvents = db.CalendarEvents.OrderBy(i => i.Year).ThenBy(i => i.Month).ToList();
        //
        // GET: /Home/
        public ActionResult Index()
        {

            string press = CultureHelper.GetCurrentNeutralCulture();
            switch (press)
            {
                case "he":
                    press = db.PressReviews.FirstOrDefault().Heb;
                    break;
                case "en":
                    press = db.PressReviews.FirstOrDefault().Eng;
                    break;
            }
            bool heb = CultureHelper.IsRighToLeft();
            StringBuilder sb = new StringBuilder();
            string hr = "<hr/>";
            foreach (var item in db.HotUpdates.OrderByDescending(i => i.Order))
            {
                sb.Append(heb ? item.Data_Heb : item.Data_Eng).Append(hr);
            }
            HomeModel hm = new HomeModel()
            {
                Posts = sb.ToString(),
                Press = press
            };
            return View(model: hm);
        }

        [HttpPost]
        public JsonResult GetNextEvent(int month, int year)
        {
            long key = month + year * 100;
            bool heb = CultureHelper.IsRighToLeft();

            var next = GetNext(key);
            if (next == null)
                return null;
            bool hasNext = HasNext(next);
            var res = new EventItem() { Month = next.Month, Year = next.Year, Data = heb ? next.Text_Heb : next.Text_Eng, HasNext = hasNext, HasPrev = true };
            return Json(res);
        }

        [HttpPost]
        public JsonResult GetPrevEvent(int month, int year)
        {
            long key = month + year * 100;
            bool heb = CultureHelper.IsRighToLeft();

            var prev = GetPrev(key);
            if (prev == null)
                return null;
            bool hasPrev = HasPrev(prev);
            var res = new EventItem() { Month = prev.Month, Year = prev.Year, Data = heb ? prev.Text_Heb : prev.Text_Eng, HasPrev = hasPrev, HasNext = true };
            return Json(res);
        }
        [HttpPost]
        public JsonResult GetCurrentEvent(int month, int year)
        {
            long key = month + year * 100;
            bool heb = CultureHelper.IsRighToLeft();
            CalendarEvent generatedEvent = null;
            generatedEvent = db.CalendarEvents.Where(i => i.CalendaryOrder == key).FirstOrDefault();
            if (generatedEvent == null)
                generatedEvent = GetNext(key);
            if (generatedEvent == null)
                generatedEvent = GetPrev(key);
            if (generatedEvent == null)
                return null;
            bool hasNext = HasNext(generatedEvent);
            bool hasPrev = HasPrev(generatedEvent);

            var res = new EventItem()
            {
                Month = generatedEvent.Month,
                Year = generatedEvent.Year,
                Data = heb ?
                generatedEvent.Text_Heb :
                generatedEvent.Text_Eng,
                HasNext = hasNext,
                HasPrev = hasPrev
            };
            return Json(res);


        }

        private CalendarEvent GetPrev(long key)
        {
            var res = db.CalendarEvents.AsEnumerable().LastOrDefault(i => i.CalendaryOrder < key);
            return res;
        }

        private bool HasPrev(CalendarEvent current)
        {
            var prevItem = db.CalendarEvents.AsEnumerable().LastOrDefault(i => i.CalendaryOrder < current.CalendaryOrder);

            return prevItem != null;
        }
        private CalendarEvent GetPrev(CalendarEvent current)
        {
            var prevItem = db.CalendarEvents.AsEnumerable().LastOrDefault(i => i.CalendaryOrder < current.CalendaryOrder);

            return prevItem;
        }

        private bool HasNext(CalendarEvent current)
        {
            var nextItem = db.CalendarEvents.AsEnumerable().FirstOrDefault(i => i.CalendaryOrder > current.CalendaryOrder);

            return nextItem != null;
        }

        private CalendarEvent GetNext(CalendarEvent current)
        {
            var nextItem = db.CalendarEvents.AsEnumerable().FirstOrDefault(i => i.CalendaryOrder > current.CalendaryOrder);

            return nextItem;
        }

        private CalendarEvent GetNext(long key)
        {
            var res = db.CalendarEvents.AsEnumerable().FirstOrDefault(i => i.CalendaryOrder > key);
            return res;
        }

        public JsonResult GePosts()
        {
            bool heb = CultureHelper.IsRighToLeft();
            StringBuilder sb = new StringBuilder();
            string hr = "<hr/>";
            foreach (var item in db.HotUpdates.OrderByDescending(i => i.Order))
            {
                sb.Append(heb ? item.Data_Heb : item.Data_Eng).Append(hr);
            }
            return Json(sb.ToString());
        }




    }
}