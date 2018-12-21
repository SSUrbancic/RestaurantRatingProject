using Microsoft.AspNet.Identity;
using RestaurantRatingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRatingProject.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //GET
        public ActionResult Reviews()
        {
            var StarRatings = new List<int>() { 1, 2, 3, 4, 5};
            ViewBag.StarRatings = new SelectList(StarRatings);

            var restaurants = db.Restaurants.ToList();

            RestaurantsRatingViewModel rrvm = new RestaurantsRatingViewModel();
            rrvm.Restaurants = restaurants;
            rrvm.Ratings = StarRatings;
            return View(rrvm);
        }
        // POST: Transactions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Reviews(Restaurant restaurant)
        {

            var starRating = restaurant.Rating;
            var RestaurantID = restaurant.RestaurantID;
            var currentUserID = User.Identity.GetUserId();
            var currentCritic = db.Critics.Where(x => x.UserID == currentUserID).Select(x => x).First();
            var currentRestaurant = db.Restaurants.Where(r => r.RestaurantID == RestaurantID).Select(r => r).First();
            var thisReview = FindOrCreateReview(currentCritic.ID, currentRestaurant.RestaurantID);
            thisReview.StarRating = starRating.GetValueOrDefault();
            var averageRating = DetermineAverageRating(RestaurantID);
            CountReviews(currentRestaurant.RestaurantID);
            currentRestaurant.AveragingRating = averageRating;
            db.SaveChanges();
            return RedirectToAction("Reviews");
        }
        public void CountReviews(int restaurantID)
        {
            var totalReviews = db.Reviews.Count();
            var reviews = db.Reviews.ToList();
            var reviewCounter = 0;
            for (int i = 0; i < totalReviews; i++)
            {                
                if(reviews[i].RestaurantID == restaurantID)
                {
                    reviewCounter++;
                }
            }
            var restaurant = db.Restaurants.Where(r => r.RestaurantID == restaurantID).Select(r => r).First();
            restaurant.NumberOfRatings = reviewCounter;
            db.SaveChanges();
        }
        public Reviews FindOrCreateReview(int criticID, int restaurantID)
        {
            Reviews thisReview;
            try
            {
                 thisReview = db.Reviews.Where(r => r.CriticID == criticID && r.RestaurantID == restaurantID).Select(r => r).First();
            }
            catch
            {
                 thisReview = new Reviews();
                 db.Reviews.Add(thisReview);
            }
            thisReview.RestaurantID = restaurantID;
            thisReview.CriticID = criticID;
            db.SaveChanges();
            return thisReview;
        }
        public double DetermineAverageRating(int restaurantID)
        {
            int sumOfRatings = 0;
            int numberOfRatings = DetermineNumberOfRatings(restaurantID);
            var tempRatingList = db.Reviews.Where(r => r.RestaurantID == restaurantID).Distinct().ToList();
            
            for (int i = 0; i < numberOfRatings; i++)
            {
                int tempRating = tempRatingList[i].StarRating;
                sumOfRatings += tempRating;
            }
            var averageRating = sumOfRatings/numberOfRatings;
            return averageRating;
        }
        public int DetermineNumberOfRatings(int restaurantID)
        {
            int numberOfRatings = db.Reviews.Where(r => r.RestaurantID == restaurantID).Select(r => r).Count();
            return numberOfRatings;
        }
    }
}