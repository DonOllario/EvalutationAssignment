using Microsoft.EntityFrameworkCore;
using PricingCalculator.DataAccess.Configurations;
using PricingCalculator.DataAccess.Entities;

namespace PricingCalculator.DataAccess;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Service> Service { get; set; }
    public DbSet<CustomerService> CustomerServices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new ServiceConfiguration());
        modelBuilder.ApplyConfiguration(new CustomerServiceConfiguration());
    }
}
