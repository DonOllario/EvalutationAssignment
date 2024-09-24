namespace PricingCalculator.Domain.Entities;

public class Service
{
    public Service()
    {
            
    }
    public Service(string name, decimal basePrice, bool isWorkingDayService)
    {
        Name = name;
        BasePrice = basePrice;
        IsWorkingDayService = isWorkingDayService;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal BasePrice { get; set; }
    public bool IsWorkingDayService { get; set; }

}
