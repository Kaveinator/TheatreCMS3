using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TheatreCMS3.Areas.Prod.Models;

namespace TheatreCMS3.Areas.Prod.Data
{
    public class ProductionContext : DbContext
    {
        public ProductionContext() : base("ProductionContext")
        {

        }

        public DbSet<Production> Productions { get; set; }
    }
}