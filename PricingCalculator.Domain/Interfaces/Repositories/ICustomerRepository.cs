using PricingCalculator.Domain.Entities;

namespace PricingCalculator.Domain.Interfaces.Repositories;

public interface ICustomerRepository
{
    Task<Guid> RegisterCustomerAsync(int freeDays);
    Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, decimal customerPrice);
    Task<List<CustomerService>> GetCustomerServicesAsync(Guid customerId);
}
