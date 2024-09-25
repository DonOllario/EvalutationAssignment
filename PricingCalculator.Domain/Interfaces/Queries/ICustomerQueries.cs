namespace PricingCalculator.Domain.Interfaces.Queries
{
    public interface ICustomerServiceQueries
    {
        Task<decimal> CalculateCustomerServicePrice(Guid customerId, DateTime startDate, DateTime endDate);
    }
}
