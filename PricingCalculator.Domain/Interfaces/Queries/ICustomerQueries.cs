namespace PricingCalculator.Domain.Interfaces.Queries
{
    public interface ICustomerQueries
    {
        Task<decimal> CalculateCustomerServicePrice(Guid customerId, DateTime startDate, DateTime endDate);
    }
}
