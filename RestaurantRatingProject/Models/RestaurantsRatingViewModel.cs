using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantRatingProject.Models
{
    public class RestaurantsRatingViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public int Rating { get; set; }
    }
}