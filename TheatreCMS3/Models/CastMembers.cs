using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Models
{
    public class CastMembers
    {
        public int CastMemberId { get; set; }
        public string Name { get; set; }
        public int? YearJoined { get; set; }
        public PositionEnum MainRole { get; set; }
        public string Bio { get; set; }
        public Byte[] Photo { get; set; }
        public bool CurrenMember { get; set; }
        public string Character { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYear { get; set; }

    }
    public enum PositionEnum
    {
        Actor,
        Director,
        Technician, 
        StageManager,
        Other
    }
    public class MyContext : DbContext 
    {
        public MyContext() : base()
        {

        }

        public DbSet<CastMembers> CastMembers { get; set; }
    }
}