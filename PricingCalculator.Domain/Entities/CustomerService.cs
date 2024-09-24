
namespace PricingCalculator.Domain.Entities;

public class CustomerService
{
    public CustomerService()
    {
            
    }

    public CustomerService(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, decimal customerPrice)
    {
        CustomerId = customerId;
        ServiceId = serviceId;
        ServiceStartDate = serviceStartDate;
        Discount = discount;
        CustomerPrice = customerPrice;
    }

    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; } 

    public Guid ServiceId { get; set; }
    public Service Service { get; set; }

    public DateTime ServiceStartDate { get; set; }
    public decimal? Discount { get; set; }
    public decimal? CustomerPrice { get; set; }
}
