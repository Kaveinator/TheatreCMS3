using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TheatreCMS3.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<TheatreCMS3.Areas.Rent.Models.RentalSurvey> RentalSurveys { get; set; }
        public System.Data.Entity.DbSet<TheatreCMS3.Areas.Prod.Models.ProductionPhoto> ProductionPhotos { get; set; }
        public System.Data.Entity.DbSet<TheatreCMS3.Areas.Rent.Models.Rental> Rentals { get; set; }
        public System.Data.Entity.DbSet<TheatreCMS3.Areas.Prod.Models.Production> Productions { get; set; }
        public System.Data.Entity.DbSet<TheatreCMS3.Areas.Rent.Models.RentalRequest> RentalRequests { get; set; }
        public System.Data.Entity.DbSet<TheatreCMS3.Areas.Prod.Models.CastMember> CastMembers { get; set; }
        public System.Data.Entity.DbSet<TheatreCMS3.Areas.Blog.Models.Comment> Comments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configures one-to-many relationship from Production to ProductionPhotos
            modelBuilder.Entity<TheatreCMS3.Areas.Prod.Models.Production>()
                .HasMany<TheatreCMS3.Areas.Prod.Models.ProductionPhoto>(p => p.ProductionPhotos) // Production has many ProductionPhotos
                .WithRequired(p => p.Production) // ProductionPhotos require a Production
                .HasForeignKey<int>(p => p.ProductionId); // Sets the foreign key for the Production in ProductionPhoto
        }

        public System.Data.Entity.DbSet<TheatreCMS3.Areas.Blog.Models.BlogPhoto> BlogPhotoes { get; set; }
    }

}