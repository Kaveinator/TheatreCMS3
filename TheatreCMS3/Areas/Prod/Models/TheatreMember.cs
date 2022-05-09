using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public enum Positions
    {
        Actor, Director, Technician, StageMananger, Other
    }
    public class TheatreMember
    {
        public int TheatreMemberId { get; set; }
        public string Name { get; set; }
        public int? YearJoined { get; set; }
        public Positions MainRole { get; set; }
        /*public byte[] Photo { get; set; }*/
        public bool CurrentMember { get; set; }
        public string Character { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYearLeft { get; set; }
    }
}