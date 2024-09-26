using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Commands;
public class CustomerCommands(ICustomerRepository _customerRepository) : ICustomerCommands
{
    public async Task<Guid> RegisterCustomerAsync(int freeDays)
    {
        var customerId = await _customerRepository.RegisterCustomerAsync(freeDays);
        return customerId;
    }
}
