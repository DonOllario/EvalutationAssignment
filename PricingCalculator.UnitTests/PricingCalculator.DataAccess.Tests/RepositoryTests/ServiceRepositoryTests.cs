using Microsoft.EntityFrameworkCore;
using PricingCalculator.DataAccess.Repositories;
using PricingCalculator.DataAccess.Tests.Configuration;
using PricingCalculator.Domain.Entities;

namespace PricingCalculator.DataAccess.Tests.RepositoryTests;

public class ServiceRepositoryTests : IDisposable
{
    private readonly ServiceRepository _serviceRepository = new(EfConfig.CreateInMemoryApplicationDbContext());
    private readonly ApplicationDbContext _testDbContext = EfConfig.CreateInMemoryTestDbContext();

    private readonly Service _service = new("Name", 0.5m, true);

    [Fact]
    public async Task RegisterServiceAsync_NewFreeDays_ShouldAddService()
    {
        await _serviceRepository.RegisterServiceAsync(_service.Name, _service.BasePrice, _service.IsWorkingDayService);

        var service = await _testDbContext.Services.SingleAsync();

        Assert.Equal(_service.Name, service.Name);
        Assert.Equal(_service.BasePrice, service.BasePrice);
        Assert.Equal(_service.IsWorkingDayService, service.IsWorkingDayService);

        Dispose();
        
    }

    public void Dispose()
    {
        _testDbContext.Database.EnsureDeleted();
        _testDbContext.Dispose();
    }
}
