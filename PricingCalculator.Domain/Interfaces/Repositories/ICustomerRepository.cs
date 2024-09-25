namespace PricingCalculator.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Guid> RegisterCustomerAsync(int freeDays);
}
