using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using CatalogApi.Data;
using CatalogApi.Models;

namespace CatalogApi.Repository
{
    public class CatalogRepository : IDisposable, ICatalogRepository
    {
        private CatalogContext _context = new CatalogContext();

        public IEnumerable<ItemCatalog> GetAll()
        {
            return _context.ItemCatalogs;
        }

        public ItemCatalog GetByID(int id)
        {
            return _context.ItemCatalogs.FirstOrDefault(p => p.ID == id);
        }
        public void Add(ItemCatalog item)
        {
            _context.ItemCatalogs.Add(item);
            _context.SaveChanges();
        }

        public void Update(ItemCatalog item)
        {
            _context.ItemCatalogs.Add(item);
            _context.SaveChanges();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}