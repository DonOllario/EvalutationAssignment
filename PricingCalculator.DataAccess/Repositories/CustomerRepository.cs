using Microsoft.EntityFrameworkCore;
using PricingCalculator.DataAccess.Entities;
using PricingCalculator.Domain.Interfaces.Repositories;
using PricingCalculator.Domain.Models.Customer;
using PricingCalculator.Domain.Models.Service;

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

    public async Task<List<CustomerServiceModel>> GetCustomerServicesAsync(Guid customerId)
    {
        var customerServices = await _context.CustomerServices
            .Where(cs => cs.CustomerId == customerId)
            .ToListAsync();

        return customerServices.Select(cs => new CustomerServiceModel
        {
            Id = cs.Id,
            Customer = new CustomerModel { Id = cs.Customer.Id, FreeDays = cs.Customer.FreeDays },
            Service = new ServiceModel { Id = cs.Service.Id, Name = cs.Service.Name, BasePrice = cs.Service.BasePrice, IsWorkingDayService = cs.Service.IsWorkingDayService  },
            ServiceStartDate = cs.ServiceStartDate,
            Discount = cs.Discount,
            CustomerPrice = cs.CustomerPrice

        }).ToList();
    }
}
