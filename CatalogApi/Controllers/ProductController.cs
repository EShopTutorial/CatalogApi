using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CatalogApi.Repository;
using CatalogApi.Models;

namespace CatalogApi.Controllers
{
    public class ProductController : ApiController
    {
        // This line of code is a problem!
        ICatalogRepository _repository;

        public ProductController(ICatalogRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ItemCatalog> Get()
        {
            return _repository.GetAll();
        }

        public IHttpActionResult Get(int id)
        {
            var product = _repository.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
