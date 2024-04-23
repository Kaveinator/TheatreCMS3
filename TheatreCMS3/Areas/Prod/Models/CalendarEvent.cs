using System;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Prod.Models {
    public class CalendarEvent {
        [Key] public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool AllDay { get; set; }
        public int TicketsAvailable { get; set; }
        public bool IsProduction { get; set; }
    }
}