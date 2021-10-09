using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TheatreCMS3.Areas.Rent.Models;
using TheatreCMS3.Models;

[assembly: OwinStartupAttribute(typeof(TheatreCMS3.Startup))]
namespace TheatreCMS3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //call the seed method
            HistoryManager.SeedHistoryManager();
            RolesManager.CreateNewRole();
        }
           
    }
    public class RolesManager
    {
        public static void CreateNewRole()
        {
            //connection to the dB
            ApplicationDbContext dbContext = new ApplicationDbContext();

            //instantiate objects - user manager and role manager
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(dbContext));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));

            //check if the role "HistoryManager" alrady exists. If not, create role
            if (!roleManager.RoleExists("HistoryManager"))
            {
                //create HistoryManager Role:
                var role = new IdentityRole()
                {
                    Name = "HistoryManager"
                };
                roleManager.Create(role);

                //find admin user by email:
                var user = userManager.FindByEmail("Admin@example.com");

                //create IdentityUser Role w/the IDs of role and user:
                var userRole = new IdentityUserRole
                {
                    RoleId = role.Id,
                    UserId = user.Id
                };

                //adding the IdentityUserRole to the user
                user.Roles.Add(userRole);
            }
        }
    }
}
