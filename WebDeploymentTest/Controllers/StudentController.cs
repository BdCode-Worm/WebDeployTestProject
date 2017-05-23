using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDeploymentTest;

namespace WebDeploymentTest.Controllers
{
    public class StudentController : Controller
    {
        private StudentDBEntities db = new StudentDBEntities();

        // GET: Student
        public ActionResult Index()
        {
            return View(db.Table_Student.ToList());
        }

        // GET: Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Student table_Student = db.Table_Student.Find(id);
            if (table_Student == null)
            {
                return HttpNotFound();
            }
            return View(table_Student);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Age,Class,Religion")] Table_Student table_Student)
        {
            if (ModelState.IsValid)
            {
                db.Table_Student.Add(table_Student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(table_Student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Student table_Student = db.Table_Student.Find(id);
            if (table_Student == null)
            {
                return HttpNotFound();
            }
            return View(table_Student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Age,Class,Religion")] Table_Student table_Student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(table_Student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(table_Student);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Table_Student table_Student = db.Table_Student.Find(id);
            if (table_Student == null)
            {
                return HttpNotFound();
            }
            return View(table_Student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Table_Student table_Student = db.Table_Student.Find(id);
            db.Table_Student.Remove(table_Student);
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
