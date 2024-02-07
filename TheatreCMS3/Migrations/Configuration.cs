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
    using TheatreCMS3.Areas.Prod.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TheatreCMS3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;

        }

        protected override void Seed(ApplicationDbContext context)
        {
            context.SeedData();
            EventPlanner.SeedEventPlanner(context);

            ////create a user role called "EventPlanner" and assign it to the EventPlanner being seeded.
            //var eventPlanner = new IdentityRole("EventPlaner");
            //context.Roles.AddOrUpdate(r => r.Name, eventPlanner);
            //context.SaveChanges();

            //EventPlanner.SeedEventPlanner(context); //call EventPlanner Method


            ////Assign EventPlanner to the "EventPlanner" role
            //var eventPlannerUser = context.Users.FirstOrDefault(u => u.UserName == "Joel");
            //if (eventPlannerUser != null)
            //{
            //    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //    userManager.AddToRole(eventPlannerUser.Id, "EventPlanner");
            //}
            //base.Seed(context);

        }


    }

}
