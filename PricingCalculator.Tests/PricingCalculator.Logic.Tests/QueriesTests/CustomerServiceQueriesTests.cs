using Moq;
using PricingCalculator.Domain.Entities;
using PricingCalculator.Domain.Interfaces.Repositories;
using PricingCalculator.Logic.Queries;

namespace PricingCalculator.Logic.Tests.QueriesTests;

public class CustomerServiceQueriesTests
{

    private readonly Mock<ICustomerServiceRepository> _customerServiceRepositoryMock;
    private readonly CustomerServiceQueries _customerServiceQueries;

    private readonly Guid _customerId = Guid.NewGuid();
    private readonly DateTime _startDate = new DateTime();
    private readonly DateTime _endDate = DateTime.Now;

    private readonly Guid _serviceId = Guid.NewGuid();
    private readonly Guid _serviceId2 = Guid.NewGuid();
    private readonly Guid _serviceId3 = Guid.NewGuid();


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

    [Theory]
    //TODO: Find a way to do the customerService list dynamic depending on customer usage.
    //[InlineData(0, 0.2, 0.0, 6.3976, "2019-09-22", "2019-09-24", "2019-09-20", "2019-10-01")] 
    [InlineData(200, 0.3, 0.0, 249.96784, "2018-01-01", "2019-10-01", "2018-01-01", "2019-10-01")] 
    public async Task CalculateCustomerServicePrice_CorrectPriceCalculation(int freeDays, decimal discount, decimal customerPrice, decimal expectedPrice, DateTime discountStart, DateTime discountEnd, DateTime serviceStart, DateTime serviceEnd)
    {

        var customer = new Customer(freeDays) { Id = _customerId };

        var customerServices = new List<CustomerService>
        {
            //new(customer.Id, _serviceId, discountStart, discount, discountStart, discountEnd, customerPrice)
            //{
            //    Customer = customer,
            //    Service = new Service("Test Service 1", 0.2m, true) { Id = _serviceId }
            //},
            new(customer.Id, _serviceId2, discountStart, discount, discountStart, discountEnd, customerPrice)
            {
                Customer = customer,
                Service = new Service("Test Service 2", 0.24m, true) { Id = _serviceId2 }
            },
            new(customer.Id, _serviceId3, discountStart, discount, discountStart, discountEnd, customerPrice)
            {
                Customer = customer,
                Service = new Service("Test Service 3", 0.4m, false) { Id = _serviceId3 }
            }
        };

        _customerServiceRepositoryMock
            .Setup(repo => repo.GetCustomerServicesAsync(_customerId))
            .ReturnsAsync(customerServices);


        var actualPrice = await _customerServiceQueries.CalculateCustomerServicePrice(_customerId, serviceStart, serviceEnd);

        Assert.Equal(expectedPrice, actualPrice);
    }
}
