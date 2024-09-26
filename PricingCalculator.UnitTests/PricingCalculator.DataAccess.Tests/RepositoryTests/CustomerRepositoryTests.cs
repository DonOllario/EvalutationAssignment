using Microsoft.EntityFrameworkCore;
using PricingCalculator.DataAccess.Repositories;
using PricingCalculator.DataAccess.Tests.Configuration;

namespace PricingCalculator.DataAccess.Tests.RepositoryTests;

public class CustomerRepositoryTests : IDisposable
{
    private readonly CustomerRepository _customerRepository = new(EfConfig.CreateInMemoryApplicationDbContext());
    private readonly ApplicationDbContext _testDbContext = EfConfig.CreateInMemoryTestDbContext();

    private const int _customerFreeDays = 5;

    [Fact]
    public async Task RegisterCustomerAsync_NewFreeDays_ShouldAddCustomer()
    {
        await _customerRepository.RegisterCustomerAsync(_customerFreeDays);

        var customer = await _testDbContext.Customers.SingleAsync();

        Assert.Equal(_customerFreeDays, customer.FreeDays);
    }

    public void Dispose()
    {
        _testDbContext.Database.EnsureDeleted();
        _testDbContext.Dispose();
    }
}
