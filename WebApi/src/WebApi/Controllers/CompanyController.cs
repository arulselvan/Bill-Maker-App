using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entity;
using WebApi.Repository;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CompanyController : Controller
    {
        private GenericRepository<Company, Guid> repository;

        public CompanyController(GenericRepository<Company, Guid> repository)
        {
            this.repository = repository;
        }
        // GET api/company
        [HttpGet]
        public IEnumerable<CompanyViewModel> Get()
        {
            var company = this.repository.Get();
            var viewModel = Mapper.Map<IEnumerable<CompanyViewModel>>(company);

            return viewModel;
        }

        // GET api/company/5
        [HttpGet("{id}")]
        public CompanyViewModel Get(Guid id)
        {
            var company = this.repository.Get(id);
            var viewModel = Mapper.Map<CompanyViewModel>(company);
            return viewModel;
        }

        // POST api/company
        [HttpPost]
        public void Post([FromBody]CompanyViewModel viewModel)
        {
            var company = Mapper.Map<Company>(viewModel);
            this.repository.Add(company);
        }

        // PUT api/company/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]CompanyViewModel viewModel)
        {
            var company = Mapper.Map<Company>(viewModel);
            this.repository.Update(id, company);
        }

        // DELETE api/company/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this.repository.Delete(id);
        }
    }
}
