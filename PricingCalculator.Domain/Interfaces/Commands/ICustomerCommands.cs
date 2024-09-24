namespace PricingCalculator.Domain.Interfaces.Commands;

public interface ICustomerCommands
{
    Task<Guid> RegisterCustomerAsync(int freeDays);
    Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, int discountDays, decimal customerPrice);

}
