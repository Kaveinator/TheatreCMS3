using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class SurveyAnalyst: ApplicationUser
    {
        public int CallBackSurveys { get; set; }

        public int SurveyTimeWindow { get; set; }
    }
}