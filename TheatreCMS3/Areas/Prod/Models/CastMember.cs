using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Prod.Models
{
    public enum PositionEnum { Actor, Director, Technician, StageManager, Other}

    public class CastMember
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> YearJoined { get; set; }   /*Is nullable*/
        public PositionEnum MainRole { get; set; }
        public string Bio { get; set; }
        //public Byte[] Photo { get; set; }   //This will be a photo of said cast member.    Commented out to be made working later in another story.
        public bool CurrentMember { get; set; }
        public string Character { get; set; }
        public Nullable<int> CastYearLeft { get; set; }  /*Is nullable*/
        public Nullable<int> DebutYear { get; set; }  /*Is nullable*/
    }  /*The layout and how this is displayed to the client will need to be updated.*/
}