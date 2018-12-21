using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RestaurantRatingProject.Models;

namespace RestaurantRatingProject.Controllers
{
    public class StarRatingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public IEnumerable<StarRatings> StarRatings()
        {
            List<StarRatings> starRatingList = new List<StarRatings>();
            for(int i=0; i<5; i++)
            {
                var tempStarRating = new StarRatings();
                var tempStarValue = i + 1;
                tempStarRating.NumberOfStars = tempStarValue;
                starRatingList.Add(tempStarRating);
            }
            return starRatingList;
        }
        // GET: StarRatings
        public ActionResult Index()
        {
            return View(db.StarRatings.ToList());
        }

        // GET: StarRatings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarRatings starRatings = db.StarRatings.Find(id);
            if (starRatings == null)
            {
                return HttpNotFound();
            }
            return View(starRatings);
        }

        // GET: StarRatings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StarRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NumberOfStars")] StarRatings starRatings)
        {
            if (ModelState.IsValid)
            {
                db.StarRatings.Add(starRatings);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(starRatings);
        }

        // GET: StarRatings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarRatings starRatings = db.StarRatings.Find(id);
            if (starRatings == null)
            {
                return HttpNotFound();
            }
            return View(starRatings);
        }

        // POST: StarRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NumberOfStars")] StarRatings starRatings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(starRatings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(starRatings);
        }

        // GET: StarRatings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StarRatings starRatings = db.StarRatings.Find(id);
            if (starRatings == null)
            {
                return HttpNotFound();
            }
            return View(starRatings);
        }

        // POST: StarRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StarRatings starRatings = db.StarRatings.Find(id);
            db.StarRatings.Remove(starRatings);
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
