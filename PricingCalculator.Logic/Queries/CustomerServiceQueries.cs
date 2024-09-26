using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Interfaces.Queries;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Queries;

public class CustomerServiceQueries(ICustomerServiceRepository _customerServiceRepository) : ICustomerServiceQueries
{
    public async Task<decimal> CalculateCustomerServicePrice(Guid customerId, DateTime startDate, DateTime endDate)
    {

        var customerServices = await _customerServiceRepository.GetCustomerServicesAsync(customerId);
        if (customerServices == null) return 0m;

        var totalPrice = 0m;
        foreach (var customerService in customerServices)
        {
            var servicePrice = CalculateServicePrice(customerService, startDate, endDate);
            totalPrice += servicePrice;
        }

        return totalPrice;
    }

    private static decimal CalculateServicePrice(CustomerService customerService, DateTime startDate, DateTime endDate)
    {
        DateTime chargeableStartDate = startDate.AddDays(customerService.Customer.FreeDays);

        var servicePrice = 0m;

        for (var date = chargeableStartDate; date <= endDate; date = date.AddDays(1))
        {
            var isApplicableDay = CalculateApplicableDays(customerService.Service.IsWorkingDayService, date);

            if (isApplicableDay)
            {
                var priceForDay = customerService.Service.BasePrice;

                if (customerService.Discount.HasValue && customerService.Discount > 0m &&
                    customerService.DiscountStart.HasValue && customerService.DiscountEnd.HasValue &&
                    date >= customerService.DiscountStart.Value && date <= customerService.DiscountEnd.Value)
                {
                    priceForDay *= (1 - customerService.Discount.Value / 100);
                }

                servicePrice += priceForDay;
            }
        }

        return servicePrice;
    }

    private static bool CalculateApplicableDays(bool isWorkingDayService, DateTime date)
    {
        if (isWorkingDayService)
        {
            return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
        }

        return true;
    }
}
