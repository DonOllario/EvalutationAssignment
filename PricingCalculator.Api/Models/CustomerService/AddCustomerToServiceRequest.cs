namespace PricingCalculator.Api.Models.CustomerService;

public record AddCustomerToServiceRequest(Guid ServiceId, DateTime ServiceStartDate, decimal Discount, DateTime DiscountStart, DateTime DiscountEnd, decimal CustomerPrice);
