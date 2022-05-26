using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastMember
    {
        // This will create PK using VS convention [className]Id
        public int CastMemberId { get; set; }
        public string Name { get; set; }
        public int? YearJoined { get; set; }
        public Placement MainRole { get; set; }
        public string Bio { get; set; }
        // public Byte[] Photo { get; set; }
        public bool CurrentMember { get; set; }
        public string Character { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYear { get; set; }
    }

    // An enum is a user-defined value type used to represent a list of named integer constants.
    // Here, we're using it to give our 'Placement' property a list of roles.
    public enum Placement
    {
        Actor,
        Director,
        Technician,
        StageManager,
        Other
    }
}