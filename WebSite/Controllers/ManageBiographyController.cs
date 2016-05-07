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
    public class ManageBiographyController : Controller
    {
        private WebDBEntities db = new WebDBEntities();

        // GET: /ManageBiography/
        public async Task<ActionResult> Index()
        {
            return View(await db.CVs.ToListAsync());
        }

        // GET: /ManageBiography/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cv = await db.CVs.FindAsync(id);
            if (cv == null)
            {
                return HttpNotFound();
            }
            return View(cv);
        }

        // GET: /ManageBiography/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManageBiography/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="ID,Heb,Eng,TimeStamp")] CV cv)
        {
            if (ModelState.IsValid)
            {
                db.CVs.Add(cv);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cv);
        }

        // GET: /ManageBiography/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cv = await db.CVs.FindAsync(id);
            if (cv == null)
            {
                return HttpNotFound();
            }
            return View(cv);
        }

        // POST: /ManageBiography/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="ID,Heb,Eng,TimeStamp")] CV cv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cv).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cv);
        }

        // GET: /ManageBiography/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CV cv = await db.CVs.FindAsync(id);
            if (cv == null)
            {
                return HttpNotFound();
            }
            return View(cv);
        }

        // POST: /ManageBiography/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CV cv = await db.CVs.FindAsync(id);
            db.CVs.Remove(cv);
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
