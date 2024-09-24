namespace PricingCalculator.DataAccess.Entities;

public class Customer
{
    public Customer()
    {
    }
    public Customer(int freeDays)
    {
            FreeDays = freeDays;
    }

    public Guid Id { get; set; }
    public int FreeDays { get; set; }

    public ICollection<CustomerService> CustomerServices { get; set; } = [];
}
