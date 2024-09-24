﻿using Microsoft.AspNetCore.Mvc;
using PricingCalculator.Api.Models.Customer;
using PricingCalculator.Domain.Interfaces.Commands;
using System.ComponentModel.DataAnnotations;

namespace PricingCalculator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerCommands _customerCommands;

        public CustomerController(ICustomerCommands customerCommands)
        {
               _customerCommands = customerCommands;
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
                var customerServiceId = await _customerCommands.RegisterCustomerToServiceAsync(customerId, request.ServiceId, request.ServiceStartDate, request.Discount, request.CustomerPrice);
                return Ok(new AddCustomerToServiceResponse(customerServiceId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
