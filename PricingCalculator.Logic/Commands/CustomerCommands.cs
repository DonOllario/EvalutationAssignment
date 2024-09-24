using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Commands
{
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
        public async Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, int discountDays, decimal customerPrice)
        {
            var customerServiceId = await _customerRepository.RegisterCustomerToServiceAsync(customerId, serviceId, serviceStartDate, discount, discountDays, customerPrice);
            return customerServiceId;
        }
    }
}
