
namespace PricingCalculator.Domain.Entities;

public class CustomerService
{
    public CustomerService()
    {
            
    }

    public CustomerService(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, DateTime discountStart, DateTime discountEnd, decimal customerPrice)
    {
        CustomerId = customerId;
        ServiceId = serviceId;
        ServiceStartDate = serviceStartDate;
        Discount = discount;
        DiscountStart = discountStart;
        DiscountEnd = discountEnd;
        CustomerPrice = customerPrice;
    }

    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } 

    public Guid ServiceId { get; set; }
    public Service Service { get; set; }

    public DateTime ServiceStartDate { get; set; }

    public decimal? Discount { get; set; }

    public DateTime? DiscountStart { get; set; }
    public DateTime? DiscountEnd { get; set; }

    public decimal? CustomerPrice { get; set; }
}
