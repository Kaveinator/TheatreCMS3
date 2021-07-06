using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    public class CastMembers
    {
        public int CastMemberId;
        public string Name;
        public int? YearJoined;
        public PositionEnum MainRole;
        public string Bio;
        public Byte[] Photo;
        public bool CurrenMember;
        public string Character;
        public int? CastYearLeft;
        public int? DebutYear;

    }

    public enum PositionEnum
    {
        Actor,
        Director,
        Technician, 
        StageManager,
        Other
    }
}