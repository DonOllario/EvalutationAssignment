using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Commands;

public class CustomerServiceCommands(ICustomerServiceRepository _customerServiceRepository) : ICustomerServiceCommands
{
    //TODO: Implement mapper from request to data object without adding any dependency to domain.
    public async Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, DateTime discountStart, DateTime discountEnd, decimal customerPrice)
    {
        var customerServiceId = await _customerServiceRepository.RegisterCustomerToServiceAsync(customerId, serviceId, serviceStartDate, discount, discountStart, discountEnd, customerPrice);
        return customerServiceId;
    }
}
