using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public enum prodPosition
    {
        Actor, Director, Technician, StageManager, Other
    }
    public class ProductionMember
    {
        public int ProductionMemberId { get; set; }
        public String Name { get; set; }
        public int? YearJoined { get; set; }
        public prodPosition MainRole { get; set; }
        public String Bio { get; set; }
        //public Byte[] Photo { get; set; }
        public bool CurrentMember { get; set; }
        public String Character { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYearLeft { get; set; }
    }
}