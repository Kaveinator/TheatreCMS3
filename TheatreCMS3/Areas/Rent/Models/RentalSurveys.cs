using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalSurveys
    {
        [Key]
        public int SurveyID { get; set; }
        public int RecommendRentalRating { get; set; }
        public int RentalCost { get; set; }
        public int ExperienceRating { get; set; }

        public  string Feedback { get; set; }
    }
}