using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Interfaces.Queries;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.Logic.Queries;

public class CustomerServiceQueries : ICustomerServiceQueries
{
    private readonly ICustomerServiceRepository _customerServiceRepository;

    public CustomerServiceQueries(ICustomerServiceRepository customerServiceRepository)
    {
        _customerServiceRepository = customerServiceRepository;
    }

    public async Task<decimal> CalculateCustomerServicePrice(Guid customerId, DateTime startDate, DateTime endDate)
    {

        var customerServices = await _customerServiceRepository.GetCustomerServicesAsync(customerId);
        if (customerServices == null) return 0m;

        decimal totalPrice = 0.00m;
        foreach (var customerService in customerServices)
        {
            decimal servicePrice = CalculateServicePrice(customerService, startDate, endDate);
            totalPrice += servicePrice;
        }

        return totalPrice;
    }


    private static decimal CalculateServicePrice(CustomerService customerService, DateTime startDate, DateTime endDate)
    {
        DateTime chargeableStartDate = startDate.AddDays(customerService.Customer.FreeDays);
        var totalDays = (endDate - chargeableStartDate).Days + 1;

        var calculatedDiscountedPrice = 0.00m;
            
        if (customerService.Discount.Value > 0.00m && customerService.DiscountStart.HasValue && customerService.DiscountEnd.HasValue) 
        {
            var applicableDiscountDays = 0;
            for (var date = customerService.DiscountStart.Value; date <= customerService.DiscountEnd.Value && date <= endDate; date = date.AddDays(1))
            {
                if(CalculateApplicableDays(customerService.Service.IsWorkingDayService, date))
                {
                    applicableDiscountDays++;
                }
                
            }
            totalDays -= applicableDiscountDays;
            calculatedDiscountedPrice = customerService.Discount.Value * applicableDiscountDays;
        }

        for (var date = chargeableStartDate; date < endDate; date = date.AddDays(1))
        {
            if (CalculateApplicableDays(customerService.Service.IsWorkingDayService, date))
            {
                totalDays--;
            }
        }

        return totalDays * customerService.Service.BasePrice + calculatedDiscountedPrice;
    }

    private static bool CalculateApplicableDays(bool isWorkingDayService, DateTime date)
    {
        var applicableDay = false;
        
        if (isWorkingDayService)
        {
            if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
            {
                applicableDay = true;
            }
        }
        else
        {
            applicableDay = true;
        }
        
        return applicableDay;
    }
}
