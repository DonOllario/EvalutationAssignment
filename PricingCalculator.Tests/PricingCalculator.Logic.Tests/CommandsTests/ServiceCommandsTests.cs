using Moq;
using PricingCalculator.Domain.Interfaces.Repositories;
using PricingCalculator.Logic.Commands;

namespace PricingCalculator.Logic.Tests.CommandsTests;

public class ServiceCommandsTests
{
    private readonly Mock<IServiceRepository> _serviceRepositoryMock;
    private readonly ServiceCommands _serviceCommands;

    private const string _name = "Name";
    private const decimal _basePrice = 0.5m;
    private const bool _isWorkingDayService = true;


    public ServiceCommandsTests()
    {
        _serviceRepositoryMock = new Mock<IServiceRepository>();
        _serviceCommands = new ServiceCommands(_serviceRepositoryMock.Object);
    }
    [Fact]
    public async Task RegisterServiceAsync_NoErrors_VerifyCalls()
    {
        await _serviceCommands.RegisterServiceAsync(_name, _basePrice, _isWorkingDayService);

        _serviceRepositoryMock.Verify(a => a.RegisterServiceAsync(_name, _basePrice, _isWorkingDayService));
    }
}
