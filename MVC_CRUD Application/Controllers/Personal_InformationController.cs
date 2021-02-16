using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_Application.Models;

namespace MVC_CRUD_Application.Controllers
{
    public class Personal_InformationController : Controller
    {
        private Personal_DetailsEntities db = new Personal_DetailsEntities();

        // GET: Personal_Information
        public ActionResult Index()
        {
            var data = db.Personal_Information.ToList();
            return View(data);
            //return View(db.Personal_Information.ToList());
        }

        // GET: Personal_Information/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Information personal_Information = db.Personal_Information.Find(id);
            if (personal_Information == null)
            {
                return HttpNotFound();
            }
            return View(personal_Information);
        }

        // GET: Personal_Information/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personal_Information/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Middle_Name,Last_Name,Mobile_Number,Email_Address,Gender,Permanent_Address")] Personal_Information personal_Information)
        {
            if (ModelState.IsValid)
            {
                db.Personal_Information.Add(personal_Information);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personal_Information);
        }

        // GET: Personal_Information/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Information personal_Information = db.Personal_Information.Find(id);
            if (personal_Information == null)
            {
                return HttpNotFound();
            }
            return View(personal_Information);
        }

        // POST: Personal_Information/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Middle_Name,Last_Name,Mobile_Number,Email_Address,Gender,Permanent_Address")] Personal_Information personal_Information)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personal_Information).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personal_Information);
        }

        // GET: Personal_Information/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personal_Information personal_Information = db.Personal_Information.Find(id);
            if (personal_Information == null)
            {
                return HttpNotFound();
            }
            return View(personal_Information);
        }

        // POST: Personal_Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personal_Information personal_Information = db.Personal_Information.Find(id);
            db.Personal_Information.Remove(personal_Information);
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
