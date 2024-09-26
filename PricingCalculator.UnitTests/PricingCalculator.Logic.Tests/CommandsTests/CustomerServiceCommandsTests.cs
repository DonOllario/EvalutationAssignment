using Moq;
using PricingCalculator.Domain.Interfaces.Repositories;
using PricingCalculator.Logic.Commands;

namespace PricingCalculator.Logic.Tests.CommandsTests;

public class CustomerServiceCommandsTests
{

    private readonly Mock<ICustomerServiceRepository> _customerServiceRepositoryMock;
    private readonly CustomerServiceCommands _customerServiceCommands;

    private readonly Guid _customerId = Guid.NewGuid();
    private readonly Guid _serviceId = Guid.NewGuid();
    private readonly DateTime _serviceStartDate = DateTime.Now;
    private const decimal _discount = 0.3m;
    private readonly DateTime _discountStart = DateTime.Now;
    private readonly DateTime _discountEnd = DateTime.Now;
    private const decimal _customerPrice = 0.0m;

    public CustomerServiceCommandsTests()
    {
        _customerServiceRepositoryMock = new Mock<ICustomerServiceRepository>();
        _customerServiceCommands = new CustomerServiceCommands(_customerServiceRepositoryMock.Object);
    }

    [Fact]
    public async Task RegisterCustomerAsync_NoErrors_VerifyCalls()
    {
        await _customerServiceCommands.RegisterCustomerToServiceAsync(_customerId, _serviceId, _serviceStartDate, _discount, _discountStart, _discountEnd, _customerPrice);

        _customerServiceRepositoryMock.Verify(a => a.RegisterCustomerToServiceAsync(_customerId, _serviceId, _serviceStartDate, _discount, _discountStart, _discountEnd, _customerPrice));
    }
}

