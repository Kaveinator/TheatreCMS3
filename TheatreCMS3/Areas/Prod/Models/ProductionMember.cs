using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionMember
    {
        public int ProductionMemberId { get; set; }
        public string Name { get; set; }
        public int YearJoined { get; set; }
        public Position MyProperty { get; set; } //need to edit
        public string Bio { get; set; }
        //public Byte Photo { get; set; }
        public bool CurrentMember { get; set; }
        public string Character { get; set; }
        public int CastYearLeft { get; set; }
        public int DebutYearLeft { get; set; }
    }

    public enum Position
    {
        Actor = 0,
        Director = 1,
        Technician = 2,
        StageManager = 3,
        Other = 4
    }
}