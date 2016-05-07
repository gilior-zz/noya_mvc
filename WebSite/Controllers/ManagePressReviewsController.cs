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
    public class ManagePressReviewsController : Controller
    {
        private WebDBEntities db = new WebDBEntities();

        // GET: /ManagePressReviews/
        public async Task<ActionResult> Index()
        {
            return View(await db.PressReviews.ToListAsync());
        }

        // GET: /ManagePressReviews/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PressReview pressreview = await db.PressReviews.FindAsync(id);
            if (pressreview == null)
            {
                return HttpNotFound();
            }
            return View(pressreview);
        }

        // GET: /ManagePressReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManagePressReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Heb,Eng,TimeStamp")] PressReview pressreview)
        {
            if (ModelState.IsValid)
            {
                db.PressReviews.Add(pressreview);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pressreview);
        }

        // GET: /ManagePressReviews/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PressReview pressreview = await db.PressReviews.FindAsync(id);
            if (pressreview == null)
            {
                return HttpNotFound();
            }
            return View(pressreview);
        }

        // POST: /ManagePressReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Heb,Eng,TimeStamp")] PressReview pressreview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pressreview).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pressreview);
        }

        // GET: /ManagePressReviews/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PressReview pressreview = await db.PressReviews.FindAsync(id);
            if (pressreview == null)
            {
                return HttpNotFound();
            }
            return View(pressreview);
        }

        // POST: /ManagePressReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PressReview pressreview = await db.PressReviews.FindAsync(id);
            db.PressReviews.Remove(pressreview);
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
