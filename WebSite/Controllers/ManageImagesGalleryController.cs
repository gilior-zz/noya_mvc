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
using System.IO;

namespace WebSite
{
    [Authorize]
    public class ManageImagesGalleryController : Controller
    {
        private WebDBEntities db = new WebDBEntities();

        // GET: /ManageImagesGallery/
        public async Task<ActionResult> Index()
        {
            return View(await db.ImagesGalleries.ToListAsync());
        }

        // GET: /ManageImagesGallery/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesGallery imagesgallery = await db.ImagesGalleries.FindAsync(id);
            if (imagesgallery == null)
            {
                return HttpNotFound();
            }
            return View(imagesgallery);
        }

        // GET: /ManageImagesGallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ManageImagesGallery/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Picture picture)
        {
            foreach (var item in picture.Files)
            {
                if (item.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(item.FileName);
                    var path = Request.MapPath("~/Images/pictures/" + fileName);
                    var relativePath = string.Format("{0}/{1}", "~/Images/pictures/", fileName);
                    ImagesGallery imagesgallery = new ImagesGallery()
                    {
                        ImagePath = relativePath
                    };
                    db.ImagesGalleries.Add(imagesgallery);
                }
            }
            await db.SaveChangesAsync();
            //        if (TryValidateModel(db))
            //        {
            //            try
            //            {
            //                await db.SaveChangesAsync();
            //            }
            //            catch (Exception)
            //            {
            //                return View(imagesgallery);

            //            }
            //            //item.SaveAs(path);

            //        }
            //        else
            //            return View(imagesgallery);
            //    }
            //    else
            //        return View();
            //}
            return RedirectToAction("Index");
            //if (ModelState.IsValid)
            //{
            //db.ImagesGalleries.Add(imagesgallery);


            // }

            //return View(imagesgallery);
        }

        // GET: /ManageImagesGallery/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesGallery imagesgallery = await db.ImagesGalleries.FindAsync(id);
            if (imagesgallery == null)
            {
                return HttpNotFound();
            }
            return View(imagesgallery);
        }

        // POST: /ManageImagesGallery/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ImageDescription,ImagePath,Visible,Order,TimeStamp")] ImagesGallery imagesgallery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagesgallery).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(imagesgallery);
        }

        // GET: /ManageImagesGallery/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ImagesGallery imagesgallery = await db.ImagesGalleries.FindAsync(id);
            if (imagesgallery == null)
            {
                return HttpNotFound();
            }
            return View(imagesgallery);
        }

        // POST: /ManageImagesGallery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ImagesGallery imagesgallery = await db.ImagesGalleries.FindAsync(id);
            var fileName = Path.GetFileName(imagesgallery.ImagePath);

            string fullPath = Request.MapPath("~/Images/" + fileName);
            if (System.IO.File.Exists(fullPath))
                System.IO.File.Delete(fullPath);
            db.ImagesGalleries.Remove(imagesgallery);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return View(imagesgallery);
            }


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

        public ActionResult UploadImage(Picture picture)
        {
            foreach (var item in picture.Files)
            {
                if (item.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(item.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    item.SaveAs(path);
                }
            }


            return RedirectToAction("Index");
        }
    }
}

