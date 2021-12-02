using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CalendarEventModel
    {
        [Key] public int EventId { get; set; }

        public string Title { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "StartDate")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "EndDate")]
        public DateTime EndDate { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "StartTime")]
        public DateTime? StartTime { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "EndTime")]
        public DateTime? EndTime { get; set; }

        public bool AllDay { get; set; }
        public int TicketsAvailable { get; set; }
        public bool IsProduction { get; set; }

        public virtual Production Production { get; set; }
    }
}