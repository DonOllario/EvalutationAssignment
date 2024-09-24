namespace PricingCalculator.Domain.Interfaces.Repositories;

public interface IServiceRepository
{
    Task<Guid> RegisterServiceAsync(string name, decimal basePrice, bool isWorkingDayService);
}
