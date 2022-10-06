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
        public int Runtime { get; set; }
        [DataType(DataType.Date)] //will only display date instead of date AND time
        public DateTime OpeningDay { get; set; }
        [DataType(DataType.Date)]
        public DateTime ClosingDay { get; set; }
        [DataType(DataType.Time)] //added so that form would accept time only format instead of date AND time
        public DateTime ShowTimeEve { get; set; }
        [DataType(DataType.Time)]
        public DateTime? ShowTimeMat { get; set; }
        public int Season { get; set; }
        public bool IsWorldPremiere { get; set; }
        public string TicketLink { get; set; }
        public bool IsCurrentlyShowing { get; set; }
    }
}