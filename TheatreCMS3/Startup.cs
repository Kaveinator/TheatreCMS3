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
                if (dbContext.HistoryManager.Count() == 0)
                {
                    //create new role
                    RolesManager.CreateNewRole();

                    //assign role to the user.
                    var user = userManager.FindByEmail("Admin@example.com");
                }
            }
        } 
    }
}
