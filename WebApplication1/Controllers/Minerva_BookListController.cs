using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Views
{
    public class Minerva_BookListController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Minerva_BookList
        public ActionResult Index()
        {
            return View(db.Minerva_BookList.ToList());
        }

        // GET: Minerva_BookList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minerva_BookList minerva_BookList = db.Minerva_BookList.Find(id);
            if (minerva_BookList == null)
            {
                return HttpNotFound();
            }
            return View(minerva_BookList);
        }

        // GET: Minerva_BookList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Minerva_BookList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,BookName,AuthorName,Price,BookCover")] Minerva_BookList minerva_BookList, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                db.Minerva_BookList.Add(minerva_BookList);
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream target = new MemoryStream();
                    file.InputStream.CopyTo(target);
                    //Minerva_BookList mb = new Minerva_BookList();
                    //mb.BookCover = target.ToArray();

                    minerva_BookList.BookCover = target.ToArray();
                }

                //var path = Path.Combine(Server.MapPath("~/Content/Files/"), file.FileName);

                //var data = new byte[file.ContentLength];
                //file.InputStream.Read(data, 0, file.ContentLength);

                //using (var sw = new FileStream(path, FileMode.Create))
                //{
                //    sw.Write(data, 0, data.Length);
                //}

                //Minerva_BookList mb = new Minerva_BookList();
                //mb.BookCover = data;


                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(minerva_BookList);
        }

        // GET: Minerva_BookList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minerva_BookList minerva_BookList = db.Minerva_BookList.Find(id);
            if (minerva_BookList == null)
            {
                return HttpNotFound();
            }
            return View(minerva_BookList);
        }

        // POST: Minerva_BookList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,BookName,AuthorName,Price,BookCover")] Minerva_BookList minerva_BookList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(minerva_BookList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(minerva_BookList);
        }

        // GET: Minerva_BookList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Minerva_BookList minerva_BookList = db.Minerva_BookList.Find(id);
            if (minerva_BookList == null)
            {
                return HttpNotFound();
            }
            return View(minerva_BookList);
        }

        // POST: Minerva_BookList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Minerva_BookList minerva_BookList = db.Minerva_BookList.Find(id);
            db.Minerva_BookList.Remove(minerva_BookList);
            db.SaveChanges();
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
