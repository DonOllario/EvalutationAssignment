namespace PricingCalculator.DataAccess.Entities;

public class Customer
{
    public int Id { get; set; }
    public DateTime ServiceStartDate { get; set; }
    public int FreeDays { get; set; }

    public ICollection<CustomerService> CustomerServices { get; set; } = [];
}
