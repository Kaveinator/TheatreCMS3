using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TheatreCMS3.Areas.Blog.Models;
using TheatreCMS3.Areas.Prod.Models;

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        
        }



        /* ▼ Put DbSet's for your models below ▼ */
        public DbSet<Comment> Comment { get; set; }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<CastMembers> CastMembers { get; set; }
        public DbSet<ProductionPhotos> ProductionPhoto { get; set; }
        public DbSet<CalendarEventsModels> CalendarEventsModels { get; set; }
        public DbSet<BlogPhoto> BlogPhoto { get; set; }


    }
}