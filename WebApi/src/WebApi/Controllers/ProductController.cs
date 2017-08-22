using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entity;
using WebApi.Repository;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly ProductRepository repository;

        public ProductController(ProductRepository repository)
        {
            this.repository = repository;
        }
        // GET api/product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            var products = this.repository.Get();

            return products;
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public ProductViewModel Get(Guid id)
        {
            var product = this.repository.Get(id);
            var viewModel = Mapper.Map<ProductViewModel>(product); 
            return viewModel;
        }

        // POST api/product
        [HttpPost]
        public void Post([FromBody]Product product)
        {
            this.repository.Post(product);
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Product viewModel)
        {
            this.repository.Put(id, viewModel);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this.repository.Delete(id);
        }
    }

    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public string profession { get; set; }
        public int schedulesCreated { get; set; }
    }
}
