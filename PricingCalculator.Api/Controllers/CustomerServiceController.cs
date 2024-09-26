using Microsoft.AspNetCore.Mvc;
using PricingCalculator.Api.Models.CustomerService;
using PricingCalculator.DataAccess.Exceptions;
using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Domain.Interfaces.Queries;

namespace PricingCalculator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerServiceController(ICustomerServiceQueries _customerServiceQueries, ICustomerServiceCommands _customerServiceCommands) : ControllerBase
{
    [HttpPost("{customerId}/service")]
    public async Task<IActionResult> AddCustomerToService(Guid customerId, [FromBody] AddCustomerToServiceRequest request)
    {
        try
        {
            var customerServiceId = await _customerServiceCommands.RegisterCustomerToServiceAsync(customerId, request.ServiceId, request.ServiceStartDate, request.Discount, request.DiscountStart, request.DiscountEnd, request.CustomerPrice);
            return Ok(new AddCustomerToServiceResponse(customerServiceId));
        }
        catch (Exception e)
        {
            if (e is CustomerServiceAlreadyRegisteredException) return Conflict($"CustomerService is already registered for this Customer");
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpGet("{customerId}/price")]
    public async Task<IActionResult> GetCustomerServicePrice(Guid customerId, [FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        try
        {
            var totalPrice = await _customerServiceQueries.CalculateCustomerServicePrice(customerId, startDate, endDate);
            return Ok(totalPrice);
        }
        catch (Exception ex)
        {

            return StatusCode(500, ex.Message);
        }
    }
}
