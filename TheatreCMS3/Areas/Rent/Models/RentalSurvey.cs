using System;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalSurvey
    {
        [Key]
        public int SurveyID { get; set; }
        public int RecommendRentalRating { get; set; }
        public int RentalCost { get; set; }
        public int ExperienceRating { get; set; }
        public String Feedback { get; set; }
    }
}