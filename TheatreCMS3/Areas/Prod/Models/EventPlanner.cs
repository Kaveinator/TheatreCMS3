using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class EventPlanner : TheatreCMS3.Models.ApplicationUser
    {
        public DateTime PlannerStartDate { get; set; }
    }
}