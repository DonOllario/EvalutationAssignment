namespace PricingCalculator.Api.Models.Customer;
public record CustomerPricingRequest(int CustomerId, DateTime StartDate, DateTime EndDate);