using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Prod.Models
    {
        public class Production
        {
            [Key]
            public int ProductionId { get; set; }

            [Required(ErrorMessage = "Title is required"), Display(Name = "Title")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Description is required"), Display(Name = "Description")]
            public string Description { get; set; } 

            [Required(ErrorMessage = "PlayWright is required"), Display(Name = "Playwright")]
            public string PlayWright { get; set; }

            [Required(ErrorMessage = "Runtime is required"), Display(Name = "Run time")]
            public int Runtime { get; set; }

            [Required(ErrorMessage = "Opening Day is required"), Display(Name = "Opening Day")]
            public DateTime OpeningDay { get; set; }

            [Required(ErrorMessage = "Closing Day is required"), Display(Name = "Closing Day")]
            public DateTime ClosingDay { get; set; }

            [DataType(DataType.Time)]
            [DisplayFormat(DataFormatString = "{0:00}", ApplyFormatInEditMode = true)]
            [Required(ErrorMessage = "Show Time is required"), Display(Name = "Show Time - Evening")]
            public DateTime ShowTimeEve { get; set; }

            [DataType(DataType.Time)]
            [DisplayFormat(DataFormatString = "{0:00}", ApplyFormatInEditMode = true)]
            [Display(Name = "Show Time - Matinee")]
            public DateTime? ShowTimeMat { get; set; }

            [Required(ErrorMessage = "Season is required"), Display(Name = "Season")]
            public int Season { get; set; }

            [Required, Display(Name = "Check if this is a world premiere:")]
            public bool IsWorldPremiere { get; set; }

            [Required(ErrorMessage = "Ticket Link is required"), Display(Name = "Link to purchase tickets")]
            public string TicketLink { get; set; }

            [Required, Display(Name = "Check if this production is currently showing:")]
            public bool IsCurrentlyShowing { get; set; }
        }
}
