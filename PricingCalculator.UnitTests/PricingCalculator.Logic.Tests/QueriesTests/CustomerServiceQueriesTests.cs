using Moq;
using PricingCalculator.Domain.Interfaces.Repositories;
using PricingCalculator.Logic.Queries;

namespace PricingCalculator.Logic.Tests.QueriesTests;

public class CustomerServiceQueriesTests
{

    private readonly Mock<ICustomerServiceRepository> _customerServiceRepositoryMock;
    private readonly CustomerServiceQueries _customerServiceQueries;

    private readonly Guid _customerId = Guid.NewGuid();
    private readonly DateTime _startDate = DateTime.Now;
    private readonly DateTime _endDate = DateTime.Now;


    public CustomerServiceQueriesTests()
    {
        _customerServiceRepositoryMock = new Mock<ICustomerServiceRepository>();
        _customerServiceQueries = new CustomerServiceQueries(_customerServiceRepositoryMock.Object);
    }

    [Fact]
    public async Task CalculateCustomerServicePrice_NoErrors_VerifyCalls()
    {
        await _customerServiceQueries.CalculateCustomerServicePrice(_customerId, _startDate, _endDate);

        _customerServiceRepositoryMock.Verify(a => a.GetCustomerServicesAsync(_customerId));
    }
}
