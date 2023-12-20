using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    public class EventPlanner : ApplicationUser
    {
        public DateTime PlannerStartDate { get; set; }
    }
}