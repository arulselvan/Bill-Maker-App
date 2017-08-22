
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entity;

namespace WebApi.Entity.Seed
{
    public class ProductSeed
    {
        private BillingDbContext billingDbContext;

        public ProductSeed(BillingDbContext billingDbContext)
        {
            this.billingDbContext = billingDbContext;
        }

        public async Task SeedData()
        {
            if (!this.billingDbContext.Company.Any())
            {
                var company = new Company
                {
                    Id = Guid.NewGuid(),
                    GstNumber = "98765432",
                    Phone = "0432876153",
                    AadharNumber = 876541018734,
                    CreatedAt = DateTime.Now,
                    CreatedBy = "sudhakar",
                    ModifiedAt = DateTime.Now,
                    ModifiedBy = "sudhakar",
                    TinNumber = "67890543"
                };

                this.billingDbContext.Company.Add(company);
            }

            if (!this.billingDbContext.Product.Any())
            {

            }
                await this.billingDbContext.SaveChangesAsync();
        }
    }
}