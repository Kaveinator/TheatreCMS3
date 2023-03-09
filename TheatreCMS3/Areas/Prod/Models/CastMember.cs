using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Prod.Models
{
    public enum PositionEnum
    {
        Actor,
        Director,
        Technician,
        StageManager,
        Other
    }

    public class CastMember
    {
        [Key]
        public int CastMemberID { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name = "Year Joined")]
        public int? YearJoined { get; set; }

        [Display(Name = "Main Role")]
        public PositionEnum MainRole { get; set; }

        [Required]
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        public byte[] Photo { get; set; }

        [Display(Name = "Current Member")]
        public bool CurrentMember { get; set; }

        [Required]
        public string Character { get; set; }

        [Display(Name = "Year Left")]
        public int? CastYearLeft { get; set; }

        [Display(Name = "Debut Year")]
        public int? DebutYear { get; set; }

        [Display(Name = "Production Title")]
        public string ProductionTitle { get; set; }
    }
}