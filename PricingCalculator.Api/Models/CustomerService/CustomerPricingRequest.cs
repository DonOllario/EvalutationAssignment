namespace PricingCalculator.Api.Models.CustomerService;
public record CustomerPricingRequest(int CustomerId, DateTime StartDate, DateTime EndDate);