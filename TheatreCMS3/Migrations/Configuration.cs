namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.IO;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TheatreCMS3.Models;
    using TheatreCMS3.Areas.Rent.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TheatreCMS3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(ApplicationDbContext context)
        {
           var new_manager = HistoryManager.createManagers();
           const string defaultRole = "HistoryManager";
           
         
            if (!context.Roles.Any(r => r.Name == defaultRole))
            {
                context.Roles.Add(new IdentityRole(defaultRole));
                context.SaveChanges();
            }

           
            if (!context.Users.Any(u => u.UserName == new_manager.UserName))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                
                manager.Create(new_manager, "somePassword");

                manager.AddToRole(new_manager.Id, defaultRole);
            }

        }
    }

}
