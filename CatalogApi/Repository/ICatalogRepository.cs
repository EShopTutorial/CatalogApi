using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CatalogApi.Models;

namespace CatalogApi.Repository
{
    public interface ICatalogRepository
    {
       IEnumerable<ItemCatalog> GetAll();
       ItemCatalog GetByID(int id);
       void Add(ItemCatalog item);
        
    }
}