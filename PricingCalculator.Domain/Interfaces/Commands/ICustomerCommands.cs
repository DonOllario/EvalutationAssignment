namespace PricingCalculator.Domain.Interfaces.Commands;

public interface ICustomerCommands
{
    Task<Guid> RegisterCustomerAsync(int freeDays);
}
