using PricingCalculator.DataAccess.Repositories;
using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Commands;

public class ServiceCommands : IServiceCommands
{
    private readonly IServiceRepository _serviceRepository;

    public ServiceCommands(IServiceRepository serviceRepository)
    {
            _serviceRepository = serviceRepository;
    }

    public async Task<Guid> RegisterServiceAsync(string name, decimal basePrice, bool isWorkingDayService)
    {
        var serviceId = await _serviceRepository.RegisterServiceAsync(name, basePrice, isWorkingDayService);
        return serviceId;
    }
}
