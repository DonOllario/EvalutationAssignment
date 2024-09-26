using PricingCalculator.Domain.Entities;

namespace PricingCalculator.Domain.Interfaces.Repositories;

public interface ICustomerServiceRepository
{
    Task<List<CustomerService>> GetCustomerServicesAsync(Guid customerId);
    Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal? discount, DateTime? discountStart, DateTime? discountEnd, decimal? customerPrice);
}
