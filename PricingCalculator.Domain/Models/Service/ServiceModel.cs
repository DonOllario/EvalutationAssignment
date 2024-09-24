namespace PricingCalculator.Domain.Models.Service;

public record ServiceModel(Guid Id, string Name, decimal BasePrice, bool IsWorkingDayService);