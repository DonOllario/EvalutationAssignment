namespace PricingCalculator.DataAccess.Entities;

public class Service
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public decimal BasePrice { get; set; }
    public bool IsWorkingDayService { get; set; }

}
