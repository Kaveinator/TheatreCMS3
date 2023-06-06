using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class Production
    {
        public int ProductionId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Playwright { get; set; }
        [Display(Name = "Run Time")]
        public int Runtime { get; set; }
        [Display(Name = "Opening Day")]
        public DateTime OpeningDay { get; set; }
        [Display(Name = "Evening Show Time")]
        public DateTime ShowTimeEve { get; set; }
        [Display(Name = "Matinee Show Time")]
        public DateTime? ShowTimeMat { get; set; }
        public int Season { get; set; }
        [Display(Name = "World Premiere")]
        public bool IsWorldPremiere { get; set; }
        [Display(Name = "Ticket Link")]
        public string TicketLink { get; set; }
        [Display(Name = "Currently Showing")]
        public bool IsCurrentlyShowing { get; set; }
    }
}