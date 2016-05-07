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

namespace WebSite
{
      [Authorize]
    public class ManageHotUpdatesController : Controller
    {
        private WebDBEntities db = new WebDBEntities();

        // GET: /ManageHotUpdates/
        public async Task<ActionResult> Index()
        {
            return View(await db.HotUpdates.ToListAsync());
        }

        // GET: /ManageHotUpdates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotUpdate hotupdate = await db.HotUpdates.FindAsync(id);
            if (hotupdate == null)
            {
                return HttpNotFound();
            }
            return View(hotupdate);
        }

        // GET: /ManageHotUpdates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManageHotUpdates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Data_Heb,Data_Eng,TimeStamp,Order")] HotUpdate hotupdate)
        {
            if (ModelState.IsValid)
            {
                db.HotUpdates.Add(hotupdate);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hotupdate);
        }

        // GET: /ManageHotUpdates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotUpdate hotupdate = await db.HotUpdates.FindAsync(id);
            if (hotupdate == null)
            {
                return HttpNotFound();
            }
            return View(hotupdate);
        }

        // POST: /ManageHotUpdates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Data_Heb,Data_Eng,TimeStamp,Order")] HotUpdate hotupdate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotupdate).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hotupdate);
        }

        // GET: /ManageHotUpdates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotUpdate hotupdate = await db.HotUpdates.FindAsync(id);
            if (hotupdate == null)
            {
                return HttpNotFound();
            }
            return View(hotupdate);
        }

        // POST: /ManageHotUpdates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HotUpdate hotupdate = await db.HotUpdates.FindAsync(id);
            db.HotUpdates.Remove(hotupdate);
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
