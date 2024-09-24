using Microsoft.AspNetCore.Mvc;
using PricingCalculator.Api.Models.Service;
using PricingCalculator.Domain.Interfaces.Commands;
using System.ComponentModel.DataAnnotations;

namespace PricingCalculator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceCommands _serviceCommands;

        public ServiceController(IServiceCommands serviceCommands)
        {
                _serviceCommands = serviceCommands;
        }
        [HttpPost]
        public async Task<IActionResult> AddService([Required][FromBody] NewServiceRequest request)
        {

            try
            {
                var serviceId = await _serviceCommands.RegisterServiceAsync(request.Name, request.BasePrice, request.IsWorkingDayService);
                return Ok(new NewServiceResponse(serviceId));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
