namespace CatalogApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using CatalogApi.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<CatalogApi.Data.CatalogContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CatalogApi.Data.CatalogContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.ItemCatalogs.AddOrUpdate(new ItemCatalog[] {
                   new ItemCatalog{ItemCategory="Cloths",ItemName="T-Shirt",ItemDescription="Green TShirt- Comfort",ItemValue=2250, Quantity=15},
            new ItemCatalog{ItemCategory="Books",ItemName="Glaciour",ItemDescription="By Ayan Rand",ItemValue=150, Quantity=25},
            new ItemCatalog{ItemCategory="Groccery",ItemName="Bikaner Snacks",ItemDescription="Plain Bhujia - 400 gm",ItemValue=50, Quantity=130}

                });
                }
    }
}
