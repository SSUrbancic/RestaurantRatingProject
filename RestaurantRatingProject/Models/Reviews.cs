using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantRatingProject.Models
{
    public class Reviews
    {
        [Key]
        public int ReviewID { get; set; }
        [ForeignKey("Critic")]
        public int CriticID { get; set; }
        public Critic Critic { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantID { get; set; }
        public Restaurant Restaurant { get; set; }
        [Display(Name = "Star Rating")]
        public int StarRating { get; set; }
    }
}