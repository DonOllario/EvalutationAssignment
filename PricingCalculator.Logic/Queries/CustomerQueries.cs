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

        var customerServices = await _customerRepository.GetCustomerServicesAsync(customerId);
        decimal totalPrice = 0;
        foreach (var customerService in customerServices)
        {
            var applicableDays = CalculateApplicableDays(customerService.Service.IsWorkingDayService, startDate, endDate);

            var basePrice = customerService.CustomerPrice;
            var discount = customerService.Discount;

            var servicePrice = (basePrice * applicableDays) * (1 - discount / 100);
        }

        return totalPrice;
    }

    private int CalculateApplicableDays(bool isWorkingDayService, DateTime startDate, DateTime endDate)
    {
        int applicableDays = 0;
        return applicableDays;
    }
}
