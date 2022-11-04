using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalSurvey
    {
        [Key]
        public int SurveyId { get; set; }
        public int ReccomendedRentingRating { get; set; }
        public int OverallExperienceRenting { get; set; }
        public string GeneralFeedback { get; set; }
    }
}