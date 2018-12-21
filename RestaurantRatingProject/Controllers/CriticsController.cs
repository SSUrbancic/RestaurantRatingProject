using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using RestaurantRatingProject.Models;

namespace RestaurantRatingProject.Controllers
{
    public class CriticsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Critics
        public ActionResult Index()
        {
            return View(db.Critics.ToList());
        }

        // GET: Critics/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Critic critic = db.Critics.Find(id);
            if (critic == null)
            {
                return HttpNotFound();
            }
            return View(critic);
        }

        // GET: Critics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Critics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,AddressLine1,AddessLine2,City,State,ZipCode")] Critic critic)
        {
            var currentUserID = User.Identity.GetUserId();
            if (ModelState.IsValid)
            {
                critic.UserID = currentUserID;
                db.Critics.Add(critic);
                db.SaveChanges();
                return RedirectToAction("Reviews", "Home");
            }
            return View(critic);
        }

        // GET: Critics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Critic critic = db.Critics.Find(id);
            if (critic == null)
            {
                return HttpNotFound();
            }
            return View(critic);
        }

        // POST: Critics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,AddressLine1,AddessLine2,City,State,ZipCode")] Critic critic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(critic).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(critic);
        }

        // GET: Critics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Critic critic = db.Critics.Find(id);
            if (critic == null)
            {
                return HttpNotFound();
            }
            return View(critic);
        }

        // POST: Critics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Critic critic = db.Critics.Find(id);
            db.Critics.Remove(critic);
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
