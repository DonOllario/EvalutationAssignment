using PricingCalculator.Domain.Models.Service;

namespace PricingCalculator.Domain.Models.Customer;

public record CustomerServiceModel(Guid Id, CustomerModel Customer, ServiceModel Service, DateTime ServiceStartDate, decimal? Discount, decimal? CustomerPrice);