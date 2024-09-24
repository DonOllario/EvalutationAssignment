using PricingCalculator.Domain.Models.Customer;

namespace PricingCalculator.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Guid> RegisterCustomerAsync(int freeDays);
    Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, decimal customerPrice);
    Task<List<CustomerServiceModel>> GetCustomerServicesAsync(Guid customerId);
}
