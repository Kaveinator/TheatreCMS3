using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CalendarEvent
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Start Date")]//Adds spacing to the name "StartDate"
        public DateTime StartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Start Time")]
        public DateTime? StartTime { get; set; }
        [Display(Name = "End Time")]
        public DateTime? EndTime { get; set; }
        [Display(Name = "All Day")]
        public bool AllDay { get; set; }
        [Display(Name = "Tickets Available")]
        public int TicketsAvailable { get; set; }
        [Display(Name = "Is Production")]
        public bool IsProduction { get; set; }
        public string Description { get; set; }
    }
}