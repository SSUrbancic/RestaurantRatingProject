using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantRatingProject.Models
{
    public class StarRatings
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "StarRating")]
        public int NumberOfStars { get; set; }
    }
}