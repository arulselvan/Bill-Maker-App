using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entity;
using WebApi.Repository;
using AutoMapper;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UnitController : Controller
    {
        private GenericRepository<Unit, Guid> repository;

        public UnitController(GenericRepository<Unit, Guid> repository)
        {
            this.repository = repository;
        }
        // GET api/unit
        [HttpGet]
        public IEnumerable<UnitViewModel> Get()
        {
            var unit = this.repository.Get();
            var viewModel = Mapper.Map<IEnumerable<UnitViewModel>>(unit);

            return viewModel;
        }

        // GET api/unit/5
        [HttpGet("{id}")]
        public UnitViewModel Get(Guid id)
        {
            var unit = this.repository.Get(id);
            var viewModel = Mapper.Map<UnitViewModel>(unit);
            return viewModel;
        }

        // POST api/unit
        [HttpPost]
        public void Post([FromBody]UnitViewModel viewModel)
        {
            var unit = Mapper.Map<Unit>(viewModel);
            this.repository.Add(unit);
        }

        // PUT api/unit/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]UnitViewModel viewModel)
        {
            var unit =  Mapper.Map<Unit>(viewModel);
            this.repository.Update(id, unit);
        }

        // DELETE api/unit/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this.repository.Delete(id);
        }
    }
}
