using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TheatreCMS3.Areas.Rent.Models
{
    public class RentalHistory
    {
        [Key]
        public int RentalHistoryId { get; set; }
        public bool RentalDamaged { get; set; }
        public string DamagesIncurred { get; set; }
        public string Rental { get; set; }


    }

    public class RentalContext : DbContext
    {
        public RentalContext() : base("RentalContext")
        {
        }

        public DbSet<RentalHistory> RentalHistories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RentalHistory>().ToTable("RentalHistory");
        }
    }
}