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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public bool AllDay { get; set; }
        public int TicketsAvailable { get; set; }
        public bool IsProduction { get; set; }
        public string Description { get; set; }
        public bool oneDay(DateTime start, DateTime end)
        {
            TimeSpan fullDay = new TimeSpan(24, 0, 0);
            if (end - start > fullDay)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Days(DateTime start, DateTime end)
        {
            TimeSpan eventDuration = end - start;
            int hours = 0;
            if (eventDuration.Hours > 0)
            {
                hours += 1;
            }
            else
            {
                hours += 0;
            }
            int days = eventDuration.Days + hours;
            return days;
        }
    }
}