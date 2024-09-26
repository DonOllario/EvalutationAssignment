using Microsoft.EntityFrameworkCore;
using PricingCalculator.Domain.Entities;
using PricingCalculator.DataAccess.Exceptions;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.DataAccess.Repositories;

public class ServiceRepository(ApplicationDbContext _context) : IServiceRepository
{
    public async Task<Guid> RegisterServiceAsync(string name, decimal basePrice, bool isWorkingDayService)
    {
        if (await _context.Services.FirstOrDefaultAsync(s => s.Name == name) is not null)
            throw new ServiceAlreadyRegisteredException();

        var newService = await _context.Services.AddAsync(new Service(name, basePrice, isWorkingDayService));
        await _context.SaveChangesAsync();

        return newService.Entity.Id;
    }
}
