namespace RestaurantRatingProject.Migrations
{
    using RestaurantRatingProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestaurantRatingProject.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestaurantRatingProject.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.
            context.Restaurants.AddOrUpdate(x => x.RestaurantID,
                new Restaurant() { RestaurantID = 1, Name = "Fleming's Wine and Steak House", Cuisine = "Steak and Wine", AveragingRating = null, NumberOfRatings = null},
                new Restaurant() { RestaurantID = 2, Name = "Bone Fish Grill", Cuisine = "Seafood/Seasonal", AveragingRating = null, NumberOfRatings = null },
                new Restaurant() { RestaurantID = 3, Name = "Kopps", Cuisine = "Burgers", AveragingRating = null, NumberOfRatings = null });
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
