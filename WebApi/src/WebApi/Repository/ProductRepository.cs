using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entity;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Repository
{
    public class ProductRepository
    {
        private readonly BillingDbContext billingDbContext;

        public ProductRepository(BillingDbContext billingDbContext)
        {
            this.billingDbContext = billingDbContext;
        }

        public IEnumerable<Product> Get()
        {
            var product = this.billingDbContext.Product
                .Include(i => i.Unit)
                .Include(i => i.Company);

            return product;
        }

        public ProductViewModel Get(Guid id)
        {
            var product = GetSingle(id);

            var viewModel = Mapper.Map<ProductViewModel>(product);

            return viewModel;
        }

        public void Post(Product product)
        {
            this.billingDbContext.Product.Add(product);
            this.billingDbContext.SaveChanges();
        }

        public void Put(Guid id, Product viewModel)
        {
            var originalUnit = GetSingle(id);
            originalUnit.Cgst = viewModel.Cgst;
            originalUnit.Code = viewModel.Code;
            originalUnit.CompanyId = viewModel.CompanyId;
            originalUnit.ExpiredDate = viewModel.ExpiredDate;
            originalUnit.ManufacturedDate = viewModel.ManufacturedDate;
            originalUnit.ModifiedAt = DateTime.Now;
            originalUnit.ModifiedBy = "sudhakar";
            originalUnit.Mrp = viewModel.Mrp;
            originalUnit.Name = viewModel.Name;
            originalUnit.Price = viewModel.Price;
            originalUnit.Quantity = viewModel.Quantity;
            originalUnit.RetailerPrice = viewModel.RetailerPrice;
            originalUnit.Sgst = viewModel.Sgst;
            originalUnit.Status = viewModel.Status;
            originalUnit.Stock = viewModel.Stock;
            originalUnit.UnitId = viewModel.UnitId;
            originalUnit.Vat = viewModel.Vat;
            this.billingDbContext.Product.Update(originalUnit);
            this.billingDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var product = GetSingle(id);
            this.billingDbContext.Product.Remove(product);
            this.billingDbContext.SaveChanges();
        }

        private Product GetSingle(Guid id)
        {
            var product = this.billingDbContext.Product
                .Include(i => i.Company)
                .Include(i => i.Unit)
                .Where(u => u.Id == id)
                .FirstOrDefault();

            return product;
        }
    }
}
