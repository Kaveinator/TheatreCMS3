using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace TheatreCMS3.Areas.Prod.Models
{
    //   public DbSet<CastMember> CastMembers { get; set; }    is in IdentityModels.cs

    public class CastMember 
    {
        // Your context has been configured to use a 'CastMember' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TheatreCMS3.Areas.Prod.Models.CastMember' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CastMember' 
        // connection string in the application configuration file.
       
        public int CastMemberId { get; set; }

        [Display(Name = "First Name")]
        public string Name { get; set; }

        [Display(Name = "Year Joined")]
        public int? YearJoined { get; set; }

        [Display(Name = "Main Role")]
        public Position MainRole { get; set; }

        public string Bio { get; set; }

        public byte[] Photo { get; set; }

        [Display(Name = "Current Member")]
        public bool CurrentMember { get; set; }

        public string Character { get; set; }

        [Display(Name = "Cast Year Left" )]
        public int? CastYearLeft { get; set; }

        [Display(Name = "Debut Year")]
        public int? DebutYear { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public enum Position
        {
            Actor,
            Director,
            Technician,
            [Display(Name = "Stage Manager")]
            StageManager,
            Other
        }
    }

}