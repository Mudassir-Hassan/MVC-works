using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolDatabase.Models;

namespace SchoolDatabase.Controllers
{
    public class ClassController : Controller
    {
        private SchoolEntities1 db = new SchoolEntities1();

        // GET: /Class/
        public ActionResult Index()
        {
            return View(db.ClassDetails.ToList());
        }

        // GET: /Class/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassDetail classdetail = db.ClassDetails.Find(id);
            if (classdetail == null)
            {
                return HttpNotFound();
            }
            return View(classdetail);
        }

        // GET: /Class/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Class/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Name_of_Class,Section,Total_Students")] ClassDetail classdetail)
        {
            if (ModelState.IsValid)
            {
                db.ClassDetails.Add(classdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classdetail);
        }

        // GET: /Class/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassDetail classdetail = db.ClassDetails.Find(id);
            if (classdetail == null)
            {
                return HttpNotFound();
            }
            return View(classdetail);
        }

        // POST: /Class/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Name_of_Class,Section,Total_Students")] ClassDetail classdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classdetail);
        }

        // GET: /Class/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassDetail classdetail = db.ClassDetails.Find(id);
            if (classdetail == null)
            {
                return HttpNotFound();
            }
            return View(classdetail);
        }

        // POST: /Class/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ClassDetail classdetail = db.ClassDetails.Find(id);
            db.ClassDetails.Remove(classdetail);
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
