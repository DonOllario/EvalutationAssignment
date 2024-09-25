using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.DataAccess.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> RegisterCustomerAsync(int freeDays)
    {
        var newCustomer = await _context.Customers.AddAsync(new Customer(freeDays));
        await _context.SaveChangesAsync();

        return newCustomer.Entity.Id;
    }

   
}
