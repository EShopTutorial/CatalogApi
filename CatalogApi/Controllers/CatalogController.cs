using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

using CatalogApi.Data;
using CatalogApi.EventBus;
using CatalogApi.Events;
using CatalogApi.Models;
using Newtonsoft.Json;

using RabbitMQ.Client;

namespace CatalogApi.Controllers
{
    [RoutePrefix("api/catalog")]
    public class CatalogController : ApiController
    {
        private CatalogContext _catalogContext;

       // private readonly IOptionsSnapshot<Settings> _settings;
        private readonly IEventBus _eventBus;

        public CatalogController()
        {
            _catalogContext = new CatalogContext();
        }


        // GET: api/Test
        [Route("")]
        public IEnumerable<ItemCatalog> Get()
        {
            return _catalogContext.ItemCatalogs.ToList();
        }


        [Route("{id:int:min(3)}")]
        public IHttpActionResult GetProduct(int id)
        {
            var product = _catalogContext.ItemCatalogs.FirstOrDefault((p) => p.ID == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);

        }

        [Route("")]
        public IHttpActionResult Post([FromBody]ItemCatalog item)
        {
            if (ModelState.IsValid) {
                _catalogContext.ItemCatalogs.Add(item);
                _catalogContext.SaveChanges();
                return Ok(item);
            }
            else
            {
                return BadRequest();

                throw new HttpResponseException(HttpStatusCode.PaymentRequired);
            }

        }

        [Route("Category/{_category}")]
        [AcceptVerbs("GET")]
        public HttpResponseMessage GetProductCategory(string _category)
        {
            //IEnumerable<ItemCatalog> products = _catalogContext.ItemCatalogs.FirstOrDefault((cat) => cat.ItemCategory == _category);

            var products = _catalogContext.ItemCatalogs.Where((cat) => cat.ItemCategory == _category).ToList();

            string jsonProduct = JsonConvert.SerializeObject(products, Formatting.Indented);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(jsonProduct, Encoding.UTF8, "application/json");
            response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                MaxAge = TimeSpan.FromMinutes(20)
            };


            return response;
        }

       
        
        [Route("")]
        public async Task<IHttpActionResult> UpdateProduct([FromBody]ItemCatalog product)
        {
            var item =  _catalogContext.ItemCatalogs.FirstOrDefault(i => i.ID == product.ID);

            if (ModelState.IsValid)
            {
                _catalogContext.ItemCatalogs.Add(item);
                _catalogContext.SaveChanges();

                var oldPrice = item.ItemValue;
                item.ItemValue = product.ItemValue;
                _catalogContext.ItemCatalogs.Add(item);
                var @event = new ProductPriceChangedIntegrationEvent(item.ID,
                item.ItemValue,
                oldPrice);

                _eventBus.Publish(@event);
                return Ok(item);
            }
            else
            {
                return BadRequest();

                throw new HttpResponseException(HttpStatusCode.PaymentRequired);
            }

        }
    }
}
