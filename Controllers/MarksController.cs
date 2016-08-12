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
    public class MarksController : Controller
    {
        private SchoolEntities1 db = new SchoolEntities1();

        // GET: /Marks/
        public ActionResult Index()
        {
            var marksheets = db.MarkSheets.Include(m => m.Studentdb);
            return View(marksheets.ToList());
        }

        // GET: /Marks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkSheet marksheet = db.MarkSheets.Find(id);
            if (marksheet == null)
            {
                return HttpNotFound();
            }
            return View(marksheet);
        }

        // GET: /Marks/Create
        public ActionResult Create()
        {
            ViewBag.Roll_No = new SelectList(db.Studentdbs, "Roll_No", "Name");
            return View();
        }

        // POST: /Marks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Roll_No,Name,Physics,Chemistry,Math,Total_Marks")] MarkSheet marksheet)
        {
            if (ModelState.IsValid)
            {
                db.MarkSheets.Add(marksheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Roll_No = new SelectList(db.Studentdbs, "Roll_No", "Name", marksheet.Roll_No);
            return View(marksheet);
        }

        // GET: /Marks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkSheet marksheet = db.MarkSheets.Find(id);
            if (marksheet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Roll_No = new SelectList(db.Studentdbs, "Roll_No", "Name", marksheet.Roll_No);
            return View(marksheet);
        }

        // POST: /Marks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Roll_No,Name,Physics,Chemistry,Math,Total_Marks")] MarkSheet marksheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(marksheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Roll_No = new SelectList(db.Studentdbs, "Roll_No", "Name", marksheet.Roll_No);
            return View(marksheet);
        }

        // GET: /Marks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MarkSheet marksheet = db.MarkSheets.Find(id);
            if (marksheet == null)
            {
                return HttpNotFound();
            }
            return View(marksheet);
        }

        // POST: /Marks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MarkSheet marksheet = db.MarkSheets.Find(id);
            db.MarkSheets.Remove(marksheet);
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
