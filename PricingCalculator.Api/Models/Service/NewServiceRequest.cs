namespace PricingCalculator.Api.Models.Service;

public record NewServiceRequest(string Name, decimal BasePrice, bool IsWorkingDayService);