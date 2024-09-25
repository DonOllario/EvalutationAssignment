using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Commands;

public class CustomerServiceCommands : ICustomerServiceCommands
{

    private readonly ICustomerServiceRepository _customerServiceRepository;

    public CustomerServiceCommands(ICustomerServiceRepository customerServiceRepository)
    {
        _customerServiceRepository = customerServiceRepository;
    }

    public async Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, DateTime discountStart, DateTime discountEnd, decimal customerPrice)
    {
        var customerServiceId = await _customerServiceRepository.RegisterCustomerToServiceAsync(customerId, serviceId, serviceStartDate, discount, discountStart, discountEnd, customerPrice);
        return customerServiceId;
    }
}
