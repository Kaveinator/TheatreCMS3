using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheatreCMS3.Areas.Prod.Models
{
        public class Program
        {
            static void Main(string[] args)
            {
                using (var db = new CastMemberContext())
                {
                 
                }
            }
        }

        public class CastMember
        {
        public enum Position { Actor, Director, Technician, StageManager, Other }; //enum for Positions

        [Key]
        public int CastMemberId { get; set; } //entity model for CastMember
        public string Name { get; set; }
        public int? YearJoined { get; set; }
        public Position MainRole { get; set; }
        public string Bio { get; set; }
        //public byte[] Photo { get; set; }  //commented out for future use
        public bool CurrentMember { get; set; }
        public string Character { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYear { get; set; }

        public virtual List<CastMember> CastMembers { get; set; }
        }
        public class CastMemberContext : DbContext
        {
            public DbSet<CastMember> CastMembers { get; set; }
        }
}
