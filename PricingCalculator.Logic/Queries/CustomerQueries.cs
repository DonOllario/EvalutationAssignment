using PricingCalculator.Domain.Interfaces.Queries;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Queries;

public class CustomerQueries : ICustomerQueries
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerQueries(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<decimal> CalculateCustomerServicePrice(Guid customerId, DateTime startDate, DateTime endDate)
    {
        decimal totalPrice = 0;
        var customerServices = await _customerRepository.GetCustomerServicesAsync(customerId);
        return totalPrice;
    }

    //public async Task<decimal> ExecuteAsync(Guid customerId, DateTime startDate, DateTime endDate)
    //{
    //    // Fetch customer and services info from the repository
    //    var customerServices = await _customerRepository.GetCustomerServicesAsync(customerId);

    //    decimal totalPrice = 0;

    //    foreach (var customerService in customerServices)
    //    {
    //        // Calculate the number of applicable days based on start and end date
    //        int applicableDays = CalculateApplicableDays(customerService.Service.Name, startDate, endDate);

    //        // Calculate the base price and apply any customer-specific discounts
    //        decimal basePrice = customerService.CustomerPrice;
    //        decimal discount = customerService.Discount;

    //        decimal servicePrice = (basePrice * applicableDays) * (1 - discount / 100);
    //        totalPrice += servicePrice;
    //    }

    //    return totalPrice;
    //}

    //private int CalculateApplicableDays(ServiceType serviceType, DateTime startDate, DateTime endDate)
    //{
    //    // Example: count weekdays for Service A/B, count all days for Service C
    //    // Implement logic to count the number of days between startDate and endDate based on the service type
    //    // Working days (Monday-Friday) for Service A/B, all days for Service C
    //    int applicableDays = 0;
    //    // Your logic for counting days goes here...
    //    return applicableDays;
    //}
}
