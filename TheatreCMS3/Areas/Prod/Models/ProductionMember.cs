using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class ProductionMember
    {
        public int ProductionMemberId { get; set; }
        public string Name { get; set; }
        public int? YearJoined { get; set; }
        public Position MainRole { get; set; }
        public string Bio { get; set; }
        public byte[] Photo { get; set; }
        public bool CurrentMember { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYearLeft { get; set; }
    }
    public enum Position
    {
        Actor,
        Director,
        Technician,
        StageManager,
        Other
    }
}