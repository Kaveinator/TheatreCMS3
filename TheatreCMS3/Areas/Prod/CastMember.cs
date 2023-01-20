using System;
using System.Data.Entity;
using System.Linq;

namespace TheatreCMS3.Areas.Prod
{
    public class CastMemberContext : DbContext
    {
        // Your context has been configured to use a 'CastMember' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TheatreCMS3.Areas.Prod.CastMember' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CastMember' 
        // connection string in the application configuration file.
        public CastMemberContext()
            : base("DefaultConnection")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<CastMember> CastMembers { get; set; }
    }

    public class CastMember
    {
        public int CastMemberId { get; set; }
        public string Name { get; set; }
        public int? YearJoined { get; set; }
        public PositionEnum MainRole { get; set; }
        public string Bio { get; set; }
        //public byte[] Photo { get; set; }
        public bool CurrentMember { get; set; }
        public string Character { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYear { get; set; }

    }
}