using PricingCalculator.DataAccess.Entities;
using PricingCalculator.Domain.Interfaces.Repositories;
namespace PricingCalculator.DataAccess.Repositories;

public class ServiceRepository : IServiceRepository
{
    private readonly ApplicationDbContext _context;

    public ServiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> RegisterServiceAsync(string name, decimal basePrice, bool isWorkingDayService)
    {
        var newService = await _context.Services.AddAsync(new Service(name, basePrice, isWorkingDayService));
        await _context.SaveChangesAsync();

        return newService.Entity.Id;
    }
}
