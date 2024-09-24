namespace PricingCalculator.Api.Models;
public record PricingRequest(int CustomerId, DateTime StartDate, DateTime EndDate);