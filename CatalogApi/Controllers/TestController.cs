using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CatalogApi.Data;
using CatalogApi.Models;

namespace CatalogApi.Controllers
{
    [RoutePrefix("api/test")]
    [Authorize]
    public class TestController : ApiController
    {

        private CatalogContext _catalogContext;
        public TestController()
        {
            _catalogContext = new CatalogContext();
        }

        [AllowAnonymous]
        // GET: api/Test
        public void Get([FromBody]string value)
        {
            throw new NotImplementedException("This method is not implemented");
        }

        [Authorize(Users = "Alice,Bob")]
        // GET: api/Test
        public IHttpActionResult Get(int id)
        {
            ItemCatalog product = _catalogContext.ItemCatalogs.FirstOrDefault(c=> c.ID == id);
            if (product == null)
            {
                return NotFound(); // Returns a NotFoundResult
            }
            return Ok(product);  // Returns an OkNegotiatedContentResult
        }

        [Authorize(Roles = "Administrators")]
        [Route("id/{id}")]
        // GET api/Books/5
        [ResponseType(typeof(ItemCatalog))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            ItemCatalog book = await _catalogContext.ItemCatalogs
                .Where(b => b.ID == id)
                .FirstOrDefaultAsync();
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }


        // POST: api/Test
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException("This method is not implemented");
        }

        // PUT: api/Test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Test/5
        public void Delete(int id)
        {
        }

        protected override void Dispose(bool disposing)
        {
            _catalogContext.Dispose();
            base.Dispose(disposing);
        }
    }
}
