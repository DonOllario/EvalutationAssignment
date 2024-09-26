using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Commands;

public class ServiceCommands(IServiceRepository _serviceRepository) : IServiceCommands
{
    public async Task<Guid> RegisterServiceAsync(string name, decimal basePrice, bool isWorkingDayService)
    {
        var serviceId = await _serviceRepository.RegisterServiceAsync(name, basePrice, isWorkingDayService);
        return serviceId;
    }
}
