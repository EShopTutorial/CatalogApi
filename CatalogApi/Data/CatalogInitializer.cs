using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using CatalogApi.Models;

namespace CatalogApi.Data
{
    public class CatalogInitializer: DropCreateDatabaseIfModelChanges<CatalogContext>
    {
        protected override void Seed(CatalogContext context)
        {
            var students = new List<ItemCatalog>
            {
            new ItemCatalog{ItemCategory="Cloths",ItemName="T-Shirt",ItemDescription="Green TShirt- Comfort",ItemValue=2250, Quantity=15},
            new ItemCatalog{ItemCategory="Books",ItemName="Glaciour",ItemDescription="By Ayan Rand",ItemValue=150, Quantity=25},
            new ItemCatalog{ItemCategory="Groccery",ItemName="Bikaner Snacks",ItemDescription="Plain Bhujia - 400 gm",ItemValue=50, Quantity=130}
            };

            students.ForEach(s => context.ItemCatalogs.Add(s));
            context.SaveChanges();
        }

    
        }
}