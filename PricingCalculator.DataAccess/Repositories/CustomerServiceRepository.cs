using Microsoft.EntityFrameworkCore;
using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.DataAccess.Repositories;

public class CustomerServiceRepository : ICustomerServiceRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerServiceRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal discount, DateTime discountStart, DateTime discountEnd, decimal customerPrice)
    {
        var customerService = await _context.CustomerServices.AddAsync(new CustomerService(customerId, serviceId, serviceStartDate, discount, discountStart, discountEnd, customerPrice));
        await _context.SaveChangesAsync();

        return customerService.Entity.Id;
    }

    public async Task<List<CustomerService>> GetCustomerServicesAsync(Guid customerId)
    {
        return await _context.CustomerServices
            .Where(cs => cs.CustomerId == customerId)
            .ToListAsync();
    }
}
