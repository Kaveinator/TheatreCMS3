using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class EventPlanner : ApplicationUser
    {
        public DateTime PlannerStartDate { get; set; }
    }
}