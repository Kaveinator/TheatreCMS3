using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheatreCMS3.Models;

namespace TheatreCMS3.Areas.Prod.Models
{
    public class CastMember
    { 
        [Key]
        public int CastMemberId { get; set; }
        [Required]
        public string Name { get; set; }
        public int? YearJoined { get; set; }
        [Required]
        public PositionEnum MainRole { get; set; }
        [Required]
        public string Bio { get; set; }
        [Required]
        public bool CurrentMember { get; set; }
        [Required]
        public string Character { get; set; }
        public int? CastYearLeft { get; set; }
        public int? DebutYear { get; set; }
        
        
        public IEnumerable<SelectListItem> ProductionsListItems { get; set; }   //List Box List-Items
        public IEnumerable<string> SelectedProductions { get; set; }            //Underlying Value (ProdId) as string.
        

        public virtual HashSet<Production> Productions { get; set; }            //Stores Prod. Objects. Result of DB call with SelectedProductions
        public CastMember() { this.Productions = new HashSet<Production>(); }   //Property Constructor for EF Nav.
        public List<string> ProductionTitles { get; set; }                      //Pulls title string from Prod objects for display.



        //Photo conversion routing
        [NotMapped]
        public HttpPostedFileBase File { get; set; }   //Input/Upload
        public byte[] Photo { get; set; }              //Conversion Output
    }
    public enum PositionEnum
    {
        Actor,
        Director,
        Technitian,
        StageManager,
        Other
    }

    public class ProdDBContext : ApplicationDbContext
    {
        public ProdDBContext() : base()
        {
        }
        public DbSet<CastMember> CastMembers { get; set; }
        public DbSet<Production> Productions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CastMember>()
            //    .HasMany<Production>(c => c.Productions)
            //    .WithMany(p => p.CastMembers)
            //    .Map(cp =>
            //    {
            //        cp.MapLeftKey("ProdId");
            //        cp.MapRightKey("CMemId");

            //        cp.ToTable("ProductionCastMembers");
            //    });
            base.OnModelCreating(modelBuilder);
        }
    }
}





    