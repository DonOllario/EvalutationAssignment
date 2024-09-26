using Microsoft.EntityFrameworkCore;
using PricingCalculator.DataAccess.Exceptions;
using PricingCalculator.DataAccess.Repositories;
using PricingCalculator.DataAccess.Tests.Configuration;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.DataAccess.Tests.RepositoryTests;

public class CustomerServiceRepositoryTests : IDisposable
{
    private readonly CustomerServiceRepository _customerServiceRepository = new(EfConfig.CreateInMemoryApplicationDbContext());
    private readonly ApplicationDbContext _testDbContext = EfConfig.CreateInMemoryTestDbContext();

    private readonly CustomerService _customerService = new(Guid.NewGuid(), Guid.NewGuid(), DateTime.Now, 0m, DateTime.Now, DateTime.Now, 0m);

    private readonly Service _service = new("Name", 0.5m, true);
    private readonly Customer _customer = new(5);

    [Fact]
    public async Task RegisterCustomerServiceAsync_CustomerToServiceAlreadyExists_ShouldThrowException()
    {
        var customerService = await _testDbContext.CustomerServices.AddAsync(_customerService);
        await _testDbContext.SaveChangesAsync();

        await Assert.ThrowsAsync<CustomerServiceAlreadyRegisteredException>(
            () => _customerServiceRepository.RegisterCustomerToServiceAsync(_customerService.CustomerId, _customerService.ServiceId, _customerService.ServiceStartDate, _customerService.Discount, _customerService.DiscountStart, _customerService.DiscountEnd, _customerService.CustomerPrice)
        );
    }

    [Fact]
    public async Task RegisterCustomerToServiceAsync_NewCustomerIdAndServiceId_ShouldAddCustomerService()
    {
        await _customerServiceRepository.RegisterCustomerToServiceAsync(_customerService.CustomerId, _customerService.ServiceId, _customerService.ServiceStartDate, _customerService.Discount, _customerService.DiscountStart, _customerService.DiscountEnd, _customerService.CustomerPrice);

        var customerService = await _testDbContext.CustomerServices.SingleAsync();
        
        Assert.Equal(_customerService.CustomerId, customerService.CustomerId);
        Assert.Equal(_customerService.ServiceId, customerService.ServiceId);
    }

    [Fact]
    public async Task GetCustomerServicesAsync_CustomerId_ShouldReturnCustomer()
    {
        _customer.Id = _customerService.CustomerId;
        _service.Id = _customerService.ServiceId;
        var customer = await _testDbContext.Customers.AddAsync(_customer);
        var service = await _testDbContext.Services.AddAsync(_service);
        var customerService = await _testDbContext.CustomerServices.AddAsync(_customerService);
        await _testDbContext.SaveChangesAsync();

        var customerServices = await _customerServiceRepository.GetCustomerServicesAsync(customerService.Entity.CustomerId);

        Assert.Contains(customerServices, cs => 
        cs.Id == customerService.Entity.Id &&
        cs.CustomerId == customerService.Entity.CustomerId &&
        cs.ServiceId == customerService.Entity.ServiceId
        );
    }


    public void Dispose()
    {
        _testDbContext.Database.EnsureDeleted();
        _testDbContext.Dispose();
    }
}
