using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace TheatreCMS3.Areas.Production.Models
{
    public class Productions

    {
        [Key]
        public int ProductionId { get; set; }
        [Required]
        public string Title { get; set; }
        public string/*?*/ Playwright { get; set; }
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OpeningDay { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ClosingDay { get; set; }
        //public ProductionPhoto Default { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime ShowtimeEve { get; set; }
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime ShowtimeMat { get; set; }
        [Required]
        public string TicketLink { get; set; }
        public int Season { get; set; }
        public bool IsCurrent { get; set; }
        //public virtual Category Category { get; set; }
    }
}