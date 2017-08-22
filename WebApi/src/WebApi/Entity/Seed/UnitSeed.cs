
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Entity.Seed
{
    public class UnitSeed
    {
        private BillingDbContext billingDbContext;

        public UnitSeed(BillingDbContext billingDbContext)
        {
            this.billingDbContext = billingDbContext;
        }

        public async Task UnitSeedData()
        {
            var name = "sudhakar";
            var date = DateTime.Now;

            if (!this.billingDbContext.Unit.Any())
            {
                var units = new List<Unit>
                {
                    new Unit {
                    Id = Guid.NewGuid(),
                    Code = "KG",
                    Description = "KG",
                    CreatedBy = name,
                    CreatedAt =  DateTime.Now
                    },
                    new Unit {
                    Id = Guid.NewGuid(),
                    Code = "Ltr",
                    Description = "Ltr",
                    CreatedBy = name,
                    CreatedAt =  DateTime.Now
                    },
                    new Unit {
                    Id = Guid.NewGuid(),
                    Code = "GRM",
                    Description = "GRM",
                    CreatedBy = name,
                    CreatedAt =  DateTime.Now
                    }
                };

                this.billingDbContext.Unit.AddRange(units);
            }

            if (!this.billingDbContext.Company.Any())
            {
                var companies = new List<Company>
                {
                    new Company {
                    Id = Guid.NewGuid(),
                    AadharNumber = 9876543210,
                    GstNumber = "123123123",
                    Name = "Saraswathi Stores",
                    Phone ="044 9987 76",
                    TinNumber ="287364873",
                    CreatedBy = name,
                    CreatedAt =  DateTime.Now
                    }
                };

                this.billingDbContext.Company.AddRange(companies);
            }
            await this.billingDbContext.SaveChangesAsync();
        }
    }
}