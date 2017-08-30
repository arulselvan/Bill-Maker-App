namespace eBilling.Api.Api
{
    using eBillingApi.Models;
    using eBillingApi.Repository;
    using MongoDB.Bson;
    using System;
    using System.Net.Http;
    using System.Web.Http;
    public class ProductController : BaseController
    {
        private readonly GenericRepository<Product> genericRepository;

        public ProductController()
        {
            this.genericRepository = new GenericRepository<Product>();
        }

        // GET api/values 
        public HttpResponseMessage Get()
        {
            var products = this.genericRepository.Get();
            return ConverToJson(products);
        }

        // GET api/values/5 
        public HttpResponseMessage Get(int id)
        {
            var products = this.genericRepository.Get(id);
            return ConverToJson(products);
        }

        // POST api/values 
        public void Post([FromBody]Product product)
        {
            this.genericRepository.Create(product);
        }

        // PUT api/values/5 
        public void Put(int id, [FromBody]Product product)
        {
            var result = this.genericRepository.Get(id);
            if (result == null)
            {
                return;
            }

            this.genericRepository.Update(id, product);
        }

        // DELETE api/values/5 
        public void Delete(int id)
        {
            this.genericRepository.Remove(id);
        }
    }
}
