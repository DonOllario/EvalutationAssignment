namespace PricingCalculator.Domain.Interfaces.Commands;

public interface IServiceCommands
{
    Task<Guid> RegisterServiceAsync(string name, decimal basePrice, bool isWorkingDayService);
}
