using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public enum PositionEnum
    {
        Actor,
        Director,
        StageManager,
        Technician,
        Other
    }
    public class CastMember
    {
        //[Key]
        public int CastMemberId { get; set; }
        public string Name { get; set; }

        [DisplayName("Year Joined")]
        public int? YearJoined { get; set; }

        [DisplayName("Main Role")]
        public PositionEnum MainRole { get; set; }
        public string Bio { get; set; }
        public byte[] Photo { get; set; }

        [DisplayName("Current Member")]
        public bool CurrentMember { get; set; }

        public string Character { get; set; }

        [DisplayName("Cast Year Left")]
        public int? CastYearLeft { get; set; }

        [DisplayName("Debut Year")]
        public int? DebutYear { get; set; }
    }
}