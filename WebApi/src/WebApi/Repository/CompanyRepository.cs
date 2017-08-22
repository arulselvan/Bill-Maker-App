using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Entity;

namespace WebApi.Repository
{
    public class CompanyRepository
    {
        private BillingDbContext billingDbContext;

        public CompanyRepository(BillingDbContext billingDbContext)
        {
            this.billingDbContext = billingDbContext;
        }

        public IEnumerable<Company> Get()
        {
            var company = this.billingDbContext.Company;
            return company;
        }

        public Company Get(Guid id)
        {
            var company =  GetSingle(id);
            return company;
        }

        public void Post(Company company)
        {
            company.Id = Guid.NewGuid();
            company.CreatedBy = "sudhakar";
            company.CreatedAt = DateTime.Now;

            this.billingDbContext.Company.Add(company);
            this.billingDbContext.SaveChanges();
        }

        public void Put(Guid id, Company unit)
        {
            var originalCompany = GetSingle(id);
            originalCompany.AadharNumber = unit.AadharNumber;
            originalCompany.GstNumber = unit.GstNumber;
            originalCompany.Name = unit.Name;
            originalCompany.Phone = unit.Phone;
            originalCompany.TinNumber = unit.TinNumber;

            originalCompany.ModifiedAt = DateTime.Now;
            originalCompany.ModifiedBy = "sudhakar";
            
            this.billingDbContext.Company.Update(originalCompany);
            this.billingDbContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var company = GetSingle(id);
            this.billingDbContext.Company.Remove(company);
            this.billingDbContext.SaveChanges();
        }

        private Company GetSingle(Guid id)
        {
            var company = this.billingDbContext.Company.Where(u => u.Id == id).FirstOrDefault();
            return company;
        }
    }
}
