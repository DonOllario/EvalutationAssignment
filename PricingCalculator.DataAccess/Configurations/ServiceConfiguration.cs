using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.DataAccess.Configurations
{
    public class ServiceConfiguration : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder
                .Property(cs => cs.BasePrice)
                .HasColumnType("decimal(4, 2)");
        }
    }
}
