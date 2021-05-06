namespace TheatreCMS3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.IO;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using TheatreCMS3.Areas.Rent.Models;
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
            RentalManager.Seed(context);

            SurveyAnalyst.SurveyAnalystSeed(context);

            HistoryManager.HistoryManagerSeed(context);

            CastDirector.CastDirectorSeed(context);

            Rental.Seed(context);
            RentalEquipment.Seed(context);
            RentalRoom.Seed(context);
            
        }
    }
}
