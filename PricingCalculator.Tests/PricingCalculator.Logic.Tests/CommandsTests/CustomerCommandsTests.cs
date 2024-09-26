using Moq;
using PricingCalculator.Domain.Interfaces.Repositories;
using PricingCalculator.Logic.Commands;

namespace PricingCalculator.Logic.Tests.CommandsTests
{
    public class CustomerCommandsTests
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;
        private readonly CustomerCommands _customerCommands;

        private const int _freeDays = 5;

        public CustomerCommandsTests()
        {
            _customerRepositoryMock = new Mock<ICustomerRepository>();
            _customerCommands = new CustomerCommands(_customerRepositoryMock.Object);
        }
        [Fact]
        public async Task RegisterCustomerAsync_NoErrors_VerifyCalls()
        {
            await _customerCommands.RegisterCustomerAsync(_freeDays);

            _customerRepositoryMock.Verify(a => a.RegisterCustomerAsync(_freeDays));
        }
    }
}