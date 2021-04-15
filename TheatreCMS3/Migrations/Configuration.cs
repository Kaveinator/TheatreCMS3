﻿namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TheatreCMS3.Areas.Prod.Models;
    using TheatreCMS3.Areas.Prod.Controllers;
    using System.IO;
    using TheatreCMS3.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<TheatreCMS3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TheatreCMS3.Models.ApplicationDbContext context)
        {
            SeedProductions(context);
            SeedProductionPhotos(context);
            SeedRolesAndUsers(context);
        }

        // Seeds productions to the database
        private void SeedProductions(TheatreCMS3.Models.ApplicationDbContext context)
        {
            context.Productions.AddOrUpdate(x => x.ProductionId,
                new Production
                {
                    ProductionId = 1,
                    Title = "Hamilton",
                    Description = "A fresh look at the era of the Founding Fathers.",
                    Playwright = "Lin-Manuel Miranda",
                    Runtime = 1,
                    OpeningDay = DateTime.Today,
                    ClosingDay = DateTime.Today,
                    ShowTimeEve = DateTime.Now,
                    ShowTimeMat = DateTime.Now,
                    Season = 1,
                    IsWorldPremiere = false,
                    TicketLink = "tickets",
                    ProPhotoID = 1
                },

                new Production
                {
                    ProductionId = 2,
                    Title = "Wicked",
                    Description = "Meet the witches of Oz before Dorothy dropped in.",
                    Playwright = "Winnie Holzman",
                    Runtime = 1,
                    OpeningDay = DateTime.Today,
                    ClosingDay = DateTime.Today,
                    ShowTimeEve = DateTime.Now,
                    ShowTimeMat = DateTime.Now,
                    Season = 1,
                    IsWorldPremiere = false,
                    TicketLink = "tickets",
                    ProPhotoID = 6
                });
        }

        // Seeds some production photos to the database
        private void SeedProductionPhotos(TheatreCMS3.Models.ApplicationDbContext context)
        {
            // Path to production photos
            string path = AppDomain.CurrentDomain.BaseDirectory + "/../Content/images/ProductionPhotos/";

            context.ProductionPhotos.AddOrUpdate(x => x.ProPhotoId,
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Hamilton",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Hamilton/01.jpg"),
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 2,
                    Title = "Hamilton 02",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Hamilton/02.jpg"),
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 3,
                    Title = "Hamilton 03",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Hamilton/03.jpg"),
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 4,
                    Title = "Hamilton 04",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Hamilton/04.jpg"),
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 5,
                    Title = "Hamilton 05",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Hamilton/05.jpg"),
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 6,
                    Title = "Wicked",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Wicked/01.jpg"),
                    ProductionId = 2
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 7,
                    Title = "Wicked 02",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Wicked/02.jpg"),
                    ProductionId = 2
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 8,
                    Title = "Wicked 03",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Wicked/03.jpg"),
                    ProductionId = 2
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 9,
                    Title = "Wicked 04",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Wicked/04.jpg"),
                    ProductionId = 2
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 10,
                    Title = "Wicked 05",
                    Description = "Photo Description",
                    Image = File.ReadAllBytes(path + "/Wicked/05.jpg"),
                    ProductionId = 2
                });
        }

        private static void SeedRolesAndUsers(ApplicationDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            // Create production photographer user role
            if (!roleManager.RoleExistsAsync("Production Photographer").Result)
            {
                var role = new IdentityRole();
                role.Name = "Production Photographer";
                roleManager.CreateAsync(role);
            }
        }

        private static void SeedUsers(UserManager<ApplicationUser> userManager)
        {
            // Seeds a default ProductionPhotographer user
            if (userManager.FindByNameAsync("ProductionPhotographer").Result == null)
            {
                var user = new ProductionPhotographer
                {
                    Id = "2",
                    UserName = "ProductionPhotographer",
                    Email = "photos@theatrevertigo.com",
                    Camera = "Camera",
                    CameraCost = 500.00,
                    CameraSerialNumber = "camera serial"
                };

                // This is where the password is set
                IdentityResult result = userManager.CreateAsync(user, "photos").Result;

                if (result.Succeeded)
                    userManager.AddToRoleAsync(user.Id, "Production Photographer").Wait();
            }
        }
    }
}
