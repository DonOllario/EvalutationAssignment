using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.DataAccess.Repositories;

public class CustomerRepository(ApplicationDbContext _context) : ICustomerRepository
{
    public async Task<Guid> RegisterCustomerAsync(int freeDays)
    {
        var newCustomer = await _context.Customers.AddAsync(new Customer(freeDays));
        await _context.SaveChangesAsync();

        return newCustomer.Entity.Id;
    }
}
