using Microsoft.EntityFrameworkCore;
using PricingCalculator.DataAccess.Exceptions;
using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Interfaces.Repositories;

namespace PricingCalculator.DataAccess.Repositories;

public class CustomerServiceRepository(ApplicationDbContext _context) : ICustomerServiceRepository
{
    public async Task<Guid> RegisterCustomerToServiceAsync(Guid customerId, Guid serviceId, DateTime serviceStartDate, decimal? discount, DateTime? discountStart, DateTime? discountEnd, decimal? customerPrice)
    {
        if (await _context.CustomerServices.FirstOrDefaultAsync(cs => cs.CustomerId == customerId && cs.ServiceId == serviceId) is not null)
            throw new CustomerServiceAlreadyRegisteredException();
       
        var customerService = await _context.CustomerServices.AddAsync(new CustomerService(customerId, serviceId, serviceStartDate, discount, discountStart, discountEnd, customerPrice));
        await _context.SaveChangesAsync();

        return customerService.Entity.Id;
    }

    public async Task<List<CustomerService>> GetCustomerServicesAsync(Guid customerId)
    {
        return await _context.CustomerServices
            .Where(cs => cs.CustomerId == customerId)
            .Include(cs => cs.Service)
            .Include(cs => cs.Customer)
            .ToListAsync();
    }
}
