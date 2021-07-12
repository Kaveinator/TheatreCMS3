using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CalendarEventsModels
    {
		[Key]
		[Required]
		public int EventId { get; set; }

		[Required]
		[Display(Name = "Title")]
		public string Title { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "Start Date")]
		public DateTime StartDate { get; set; }

		[Required]
		[DataType(DataType.Date)]
		[Display(Name = "End Date")]
		public DateTime EndDate { get; set; }

		[Display(Name = "Start Time")]
		[DataType(DataType.Time)]
		[DisplayFormat(ApplyFormatInEditMode=true, DataFormatString= "{0:h:mm:ss tt}")]
		public DateTime? StartTime { get; set; }

		[Display(Name = "End Time")]
		[DataType(DataType.Time)]
		public DateTime? EndTime { get; set; }

		[Required]
		[Display(Name = "All Day Event?")]
		public bool AllDay { get; set; }

		[Required]
		[Display(Name = "Tickets Available")]
		public int TicketsAvailable { get; set; }

		[Required]
		[Display(Name = "Production?")]
		public bool isProduction { get; set; }
	}
}