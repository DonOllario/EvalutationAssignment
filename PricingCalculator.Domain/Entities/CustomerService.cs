﻿
namespace PricingCalculator.Domain.Entities;

public class CustomerService
{
    public CustomerService()
    {
            
    }

    public CustomerService(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, int discountDays,decimal customerPrice)
    {
        CustomerId = customerId;
        ServiceId = serviceId;
        ServiceStartDate = serviceStartDate;
        Discount = discount;
        DiscountDays = discountDays;
        CustomerPrice = customerPrice;
    }

    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } 

    public Guid ServiceId { get; set; }
    public Service Service { get; set; }

    public DateTime ServiceStartDate { get; set; }
    public decimal? Discount { get; set; }
    //Make DiscountDays start and end dates
    public int DiscountDays { get; set; }
    public decimal? CustomerPrice { get; set; }
}
