namespace PricingCalculator.Domain.Interfaces.Commands;

public interface ICustomerServiceCommands
{
    Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, DateTime discountStart, DateTime discountEnd, decimal customerPrice);
}
