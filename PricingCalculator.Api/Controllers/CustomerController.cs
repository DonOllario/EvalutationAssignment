using Microsoft.AspNetCore.Mvc;
using PricingCalculator.Api.Models.Customer;
using PricingCalculator.Domain.Interfaces.Commands;
using PricingCalculator.Domain.Interfaces.Queries;
using System.ComponentModel.DataAnnotations;

namespace PricingCalculator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerCommands _customerCommands;
        private readonly ICustomerServiceQueries _customerServiceQueries;
        private readonly ICustomerServiceCommands _customerServiceCommands;

        public CustomerController(ICustomerCommands customerCommands, ICustomerServiceQueries customerServiceQueries, ICustomerServiceCommands customerServiceCommands)
        {
            _customerCommands = customerCommands;
            _customerServiceQueries = customerServiceQueries;
            _customerServiceCommands = customerServiceCommands;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([Required] [FromBody] NewCustomerRequest request)
        {

            try
            {
                var customerId = await _customerCommands.RegisterCustomerAsync(request.FreeDays);
                return Ok(new NewCustomerResponse(customerId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("customers/{customerId}/service")]
        public async Task<IActionResult> AddCustomerToService(Guid customerId, [FromBody] AddCustomerToServiceRequest request)
        {

            try
            {
                var customerServiceId = await _customerServiceCommands.RegisterCustomerToServiceAsync(customerId, request.ServiceId, request.ServiceStartDate, request.Discount, request.DiscountStart, request.DiscountEnd, request.CustomerPrice);
                return Ok(new AddCustomerToServiceResponse(customerServiceId));
            }
            catch (Exception e)
            {
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
}
