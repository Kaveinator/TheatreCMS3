using TheatreCMS3.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TheatreCMS3.Areas.Rent.Models;

namespace TheatreCMS3.DAL
{
    public class RentalHistoryContext : DbContext
    {
        public RentalHistoryContext() : base("name=DefaultConnection") //the name of the (database) connection string is DefaultConnection found in the web.config file
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>(); //prevents table names from being pluralized
        }

        public System.Data.Entity.DbSet<TheatreCMS3.Areas.Rent.Models.RentalHistory> RentalHistories { get; set; }
        //public System.Data.Entity.DbSet<TheatreCMS3.Areas.Rent.Models.HistoryManager> HistoryManagers { get; set; }
    }
}