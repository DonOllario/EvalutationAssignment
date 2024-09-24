using PricingCalculator.Domain.Interfaces;

namespace PricingCalculator.Api.Configuration;

public class AppConfig : IAppConfig
{
    public string Environment { get; set; } = string.Empty;
}
