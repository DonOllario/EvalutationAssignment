
namespace PricingCalculator.DataAccess.Entities;

public class CustomerService
{
    public Guid Id { get; set; }

    public Guid CustomerId { get; set; }
    public required Customer Customer { get; set; } 

    public Guid ServiceId { get; set; }
    public required Service Service { get; set; }

    public DateTime ServiceStartDate { get; set; }
    public decimal? Discount { get; set; }
    public decimal? CustomerPrice { get; set; }
}
