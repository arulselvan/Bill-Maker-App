using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entity;

namespace WebApi.Repository
{
    public class UnitRepository
    {
        private readonly BillingDbContext billingDbContext;

        public UnitRepository(BillingDbContext billingDbContext)
        {
            this.billingDbContext = billingDbContext;
        }

        public IEnumerable<UnitViewModel> Get()
        {
            var unit = this.billingDbContext.Unit;
            var viewModel = Mapper.Map<IEnumerable<UnitViewModel>>(unit);
            return viewModel;
        }

        public UnitViewModel Get(Guid id)
        {
            var unit = GetSingle(id);

            var viewModel = Mapper.Map<UnitViewModel>(unit);

            return viewModel;
        }

        public void Post(UnitViewModel viewModel)
        {
            var unit = Mapper.Map<Unit>(viewModel);

            this.billingDbContext.Unit.Add(unit);
            this.billingDbContext.SaveChanges();
        }

        public void Put(Guid id, UnitViewModel viewModel)
        {
            var originalUnit = GetSingle(id);
            Mapper.Map(viewModel, originalUnit);
            this.billingDbContext.Unit.Update(originalUnit);
            this.billingDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var unit = GetSingle(id);
            this.billingDbContext.Unit.Remove(unit);
            this.billingDbContext.SaveChanges();
        }

        private Unit GetSingle(Guid id)
        {
            var unit = this.billingDbContext.Unit.Where(u => u.Id == id).FirstOrDefault();

            return unit;
        }
    }
}
