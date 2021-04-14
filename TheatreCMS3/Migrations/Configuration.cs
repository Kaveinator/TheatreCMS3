namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TheatreCMS3.Areas.Prod.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TheatreCMS3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TheatreCMS3.Models.ApplicationDbContext context)
        {
            // Seed productions and photos then connect them properly
            SeedProductions(context);
            SeedProductionPhotos(context);
            ConnectSeededProductionsWithPhotos();
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
                    TicketLink = "tickets"
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
                    TicketLink = "tickets"
                });
        }

        // Seeds some production photos to the database
        private void SeedProductionPhotos(TheatreCMS3.Models.ApplicationDbContext context)
        {
            context.ProductionPhotos.AddOrUpdate(x => x.ProPhotoId,
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Hamilton",
                    Description = "Photo Description",
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Hamilton 02",
                    Description = "Photo Description",
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Hamilton 03",
                    Description = "Photo Description",
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Hamilton 04",
                    Description = "Photo Description",
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Hamilton 05",
                    Description = "Photo Description",
                    ProductionId = 1
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Wicked",
                    Description = "Photo Description",
                    ProductionId = 2
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Wicked 02",
                    Description = "Photo Description",
                    ProductionId = 2
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Hamilton 03",
                    Description = "Photo Description",
                    ProductionId = 2
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Hamilton 04",
                    Description = "Photo Description",
                    ProductionId = 2
                },
                new ProductionPhoto()
                {
                    ProPhotoId = 1,
                    Title = "Hamilton 05",
                    Description = "Photo Description",
                    ProductionId = 2
                });
        }

        private void ConnectSeededProductionsWithPhotos()
        {

        }
    }
}
