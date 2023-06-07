using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Optimization;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CalenderEvent
    {
        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool Allday { get; set; }
        public int TicketsAvailable { get; set; }
        public bool isProduction { get; set; }
    }
}