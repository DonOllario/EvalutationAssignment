using PricingCalculator.DataAccess.Entities;
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

    public async Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, decimal customerPrice)
    {
        var customerService = await _context.CustomerServices.AddAsync(new CustomerService(customerId, serviceId, serviceStartDate, discount, customerPrice));
        await _context.SaveChangesAsync();

        return customerService.Entity.Id;
    }
}
