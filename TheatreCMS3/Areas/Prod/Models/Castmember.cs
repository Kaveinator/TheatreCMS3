using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class Castmember
    {
        public int CastMemberId { get; set; }
        public string Name { get; set; }
        public int? YearJoined { get; set; }
        public position MainRole { get; set; }
        public string Bio { get; set; }

        //Photo will be used in a later story, so it is not needed until then
        //public byte[] Photo { get; set; }
        public bool CurrentMember { get; set; }
        public string Character { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYear { get; set; }
        }

    public enum position
    {
        Actor,
        Director,
        Technician,
        StageManager,
        Other
    }
}