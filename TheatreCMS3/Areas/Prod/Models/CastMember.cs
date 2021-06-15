using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastMember
    { 
        //Created an Enum for the MainRole property
        public enum PositionEnum
        {
            Actor,
            Director,
            Technician,
            StageManager,
            Other
        }

        public int CastMemberId { get; set; }

        public string Name { get; set; }

        public int? YearJoined { get; set; }

        public PositionEnum MainRole { get; set; }

        public string Bio { get; set; } 


        // Commenting out for later code use
        //public Byte[] Photo { get; set; }

        public bool CurrentMember { get; set; }

        public string Character { get; set; }

        public int? CastYearLeft { get; set; }

        public int? DebutYear { get; set; }
        
       
    }
}