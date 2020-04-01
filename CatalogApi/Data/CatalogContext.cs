using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using CatalogApi.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CatalogApi.Data
{
    public class CatalogContext : DbContext
    {
        public CatalogContext() : base("CatalogDB")
        {
        }

        public DbSet<ItemCatalog> ItemCatalogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}