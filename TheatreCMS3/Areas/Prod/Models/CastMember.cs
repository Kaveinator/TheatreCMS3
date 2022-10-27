using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastMember
    {
        public int CastMemberId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public byte[] Photo { get; set; }
        public int? YearJoined { get; set; }
        public int? YearLeft { get; set; }
        public PositionEnum MainRole { get; set; }
        public bool CurrentMember { get; set; }
        public bool AssociateArtist { get; set; }
        public bool EnsembleMember { get; set; }
        public int? DebutYear { get; set; }
        public string ProductionTitle { get; set; }
    }

    public enum PositionEnum
    {
        Actor,
        Director,
        StageManager,
        Technician,
        Other
    }
}