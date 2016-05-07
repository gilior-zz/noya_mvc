using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebSite;

namespace WebSite.Controllers
{
    public class ManageCalendarEventsController : Controller
    {
        private WebDBEntities db = new WebDBEntities();

        // GET: /ManageCalendarEvents/
        public async Task<ActionResult> Index()
        {
            return View(await db.CalendarEvents.ToListAsync());
        }

        // GET: /ManageCalendarEvents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarevent = await db.CalendarEvents.FindAsync(id);
            if (calendarevent == null)
            {
                return HttpNotFound();
            }
            return View(calendarevent);
        }

        // GET: /ManageCalendarEvents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManageCalendarEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Month,Year,Tex_Heb,Tex_Eng,Visible,TimeStamp")] CalendarEvent calendarevent)
        {
            if (ModelState.IsValid)
            {
                db.CalendarEvents.Add(calendarevent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(calendarevent);
        }

        // GET: /ManageCalendarEvents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarevent = await db.CalendarEvents.FindAsync(id);
            if (calendarevent == null)
            {
                return HttpNotFound();
            }
            return View(calendarevent);
        }

        // POST: /ManageCalendarEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Month,Year,Tex_Heb,Tex_Eng,Visible,TimeStamp")] CalendarEvent calendarevent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendarevent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(calendarevent);
        }

        // GET: /ManageCalendarEvents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarEvent calendarevent = await db.CalendarEvents.FindAsync(id);
            if (calendarevent == null)
            {
                return HttpNotFound();
            }
            return View(calendarevent);
        }

        // POST: /ManageCalendarEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CalendarEvent calendarevent = await db.CalendarEvents.FindAsync(id);
            db.CalendarEvents.Remove(calendarevent);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
