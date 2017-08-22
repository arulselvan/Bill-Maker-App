using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace WebApi.Entity
{
    public class BillingDbContext : DbContext
    {
        private IConfigurationRoot _config;

        public BillingDbContext(IConfigurationRoot config, DbContextOptions options) : base(options)
        {
            _config = config;
        }

        public DbSet<Unit> Unit { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.Entity<Product>().HasOne(e => e.Unit).WithMany(c => c.Product);
            // modelBuilder.Entity<Product>().HasOne(e => e.Company).WithMany(c => c.Product);
        }
    }
}