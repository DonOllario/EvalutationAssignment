namespace PricingCalculator.Api.Models.Customer;

public record AddCustomerToServiceRequest(Guid ServiceId, DateTime ServiceStartDate, decimal Discount, int DiscountDays, decimal CustomerPrice);
