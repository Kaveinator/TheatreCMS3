using Microsoft.AspNet.Identity.EntityFramework;
using System;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    // EventPlanner class inherits from ApplicationUser
    public class EventPlanner : ApplicationUser
    {
        // The PlannerStartDate property stores when the event planner started at the position
        public DateTime PlannerStartDate { get; set; }
    }
}