using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Commands;
public class CustomerCommands : ICustomerCommands
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerCommands(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<Guid> RegisterCustomerAsync(int freeDays)
    {
        var customerId = await _customerRepository.RegisterCustomerAsync(freeDays);
        return customerId;
    }
}
