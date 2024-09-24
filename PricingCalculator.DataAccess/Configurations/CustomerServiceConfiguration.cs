using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.DataAccess.Configurations
{
    public class CustomerServiceConfiguration : IEntityTypeConfiguration<CustomerService>
    {
        public void Configure(EntityTypeBuilder<CustomerService> builder)
        {
            builder
                .Property(cs => cs.Discount)
                .HasColumnType("decimal(4, 2)");

            builder
                .Property(cs => cs.CustomerPrice)
                .HasColumnType("decimal(4, 2)");
        }
    }
}
