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

    [Fact]
    public async Task RegisterCustomerServiceAsync_CustomerToServiceAlreadyExists_ShouldThrowException()
    {
        var customerService = await _testDbContext.CustomerServices.AddAsync(_customerService);
        await _testDbContext.SaveChangesAsync();

        await Assert.ThrowsAsync<CustomerServiceAlreadyRegisteredException>(
            () => _customerServiceRepository.RegisterCustomerToServiceAsync(_customerService.CustomerId, _customerService.ServiceId, _customerService.ServiceStartDate, _customerService.Discount, _customerService.DiscountStart, _customerService.DiscountEnd, _customerService.CustomerPrice)
        );

        Dispose();
    }

    [Fact]
    public async Task RegisterCustomerToServiceAsync_NewCustomerIdAndServiceId_ShouldAddCustomerService()
    {
        await _customerServiceRepository.RegisterCustomerToServiceAsync(_customerService.CustomerId, _customerService.ServiceId, _customerService.ServiceStartDate, _customerService.Discount, _customerService.DiscountStart, _customerService.DiscountEnd, _customerService.CustomerPrice);

        var customerService = await _testDbContext.CustomerServices.SingleAsync();
        
        Assert.Equal(_customerService.CustomerId, customerService.CustomerId);
        Assert.Equal(_customerService.ServiceId, customerService.ServiceId);

        Dispose();
    }

    public void Dispose()
    {
        _testDbContext.Database.EnsureDeleted();
        _testDbContext.Dispose();
    }
}
