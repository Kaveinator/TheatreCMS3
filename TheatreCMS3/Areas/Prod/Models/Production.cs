using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public int Runtime { get; set; }
        [DisplayName("Opening Day")]
        public DateTime OpeningDay { get; set; }
        [DisplayName("Closing Day")]
        public DateTime ClosingDay { get; set; }
        [DisplayName("Evening Showtime")]
        public DateTime ShowTimeEve { get; set; }
        [DisplayName("Matinee Showtime")]
        public DateTime? ShowTimeMat { get; set; }
        public int Season { get; set; }
        [DisplayName("Is World Premiere?")]
        public bool IsWorldPremiere { get; set; }
        [DisplayName("Ticket Link")]
        public string TicketLink { get; set; }

        public bool IsCurrentlyShowing() => DateTime.Now < ClosingDay;
    }
}