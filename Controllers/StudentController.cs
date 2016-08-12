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
    public class StudentController : Controller
    {
        private SchoolEntities1 db = new SchoolEntities1();

        // GET: /Student/
        public ActionResult Index()
        {
            var studentdbs = db.Studentdbs.Include(s => s.MarkSheet);
            return View(studentdbs.ToList());
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentdb studentdb = db.Studentdbs.Find(id);
            if (studentdb == null)
            {
                return HttpNotFound();
            }
            return View(studentdb);
        }

        // GET: /Student/Create
        public ActionResult Create()
        {
            ViewBag.Roll_No = new SelectList(db.MarkSheets, "Roll_No", "Name");
            return View();
        }

        // POST: /Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Roll_No,Name,Father_Name,Gender,Address,DOB")] Studentdb studentdb)
        {
            if (ModelState.IsValid)
            {
                db.Studentdbs.Add(studentdb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Roll_No = new SelectList(db.MarkSheets, "Roll_No", "Name", studentdb.Roll_No);
            return View(studentdb);
        }

        // GET: /Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentdb studentdb = db.Studentdbs.Find(id);
            if (studentdb == null)
            {
                return HttpNotFound();
            }
            ViewBag.Roll_No = new SelectList(db.MarkSheets, "Roll_No", "Name", studentdb.Roll_No);
            return View(studentdb);
        }

        // POST: /Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Roll_No,Name,Father_Name,Gender,Address,DOB")] Studentdb studentdb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentdb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Roll_No = new SelectList(db.MarkSheets, "Roll_No", "Name", studentdb.Roll_No);
            return View(studentdb);
        }

        // GET: /Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Studentdb studentdb = db.Studentdbs.Find(id);
            if (studentdb == null)
            {
                return HttpNotFound();
            }
            return View(studentdb);
        }

        // POST: /Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Studentdb studentdb = db.Studentdbs.Find(id);
            db.Studentdbs.Remove(studentdb);
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
