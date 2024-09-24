
namespace PricingCalculator.DataAccess.Entities;

public class CustomerService
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public required Customer Customer { get; set; } 

    public int ServiceId { get; set; }
    public required Service Service { get; set; } 

    public decimal Discount { get; set; }
    public decimal CustomerPrice { get; set; }
}
