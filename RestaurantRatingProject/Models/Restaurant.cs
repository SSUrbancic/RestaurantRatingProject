using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantRatingProject.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantID { get; set; }
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }
        [Display(Name = "Cuisine")]
        public string Cuisine { get; set; }
        [Display(Name = "Average Rating")]
        public double? AveragingRating { get; set; }
        [Display(Name = "Number Of Ratings")]
        public int? NumberOfRatings { get; set; }
        [Display(Name = "Star Ratings")]
        public List<int> StarRatings { get; set; }
        [Display(Name = "Star Ratings")]
        public int? Rating { get; set; }

    }
}