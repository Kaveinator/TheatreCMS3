using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastMember
    {
        [Key]
        public int CastMemberID { get; set; }
        [Required]
        public string Name { get; set; }
        public int? YearJoined { get; set; }
        [Required]
        public PositionEnum MainRole { get; set; }
        [Required]
        public string Bio { get; set; }
        public byte[] Photo { get; set; }
        [Required]
        public bool CurrentMember { get; set; }
        [Required]
        public string Character { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYear { get; set; }

    }
    public enum PositionEnum
    {
        Actor,
        Director,
        Technitian,
        StageManager,
        Other
    }
}  