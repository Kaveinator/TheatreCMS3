using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Prod.Models
{
    public enum Position
    {
        Actor, Director, Technician, StageManager, Other
    }

    public class CastMember
    {
        [DisplayName("Cast Member ID")]
        public int CastMemberId { get; set; }
        public string Name { get; set; }
        [DisplayName("Year Joined")]
        public int? YearJoined { get; set; }
        [DisplayName("Main Role")]
        public Position MainRole { get; set; }
        public string Bio { get; set; }
        [DisplayName("Current Member")]
        public bool CurrentMember { get; set; }
        [DisplayName("Production Title")]
        public string ProductionTitle { get; set; }
        public string Character { get; set; }
        [DisplayName("Cast Year Left")]
        public int? CastYearLeft { get; set; }
        [DisplayName("Debut Year")]
        public int? DebutYear { get; set; }
        public byte[] Photo { get; set; }
    }
}