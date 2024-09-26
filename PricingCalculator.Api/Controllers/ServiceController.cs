using Microsoft.AspNetCore.Mvc;
using PricingCalculator.Api.Models.Service;
using PricingCalculator.DataAccess.Exceptions;
using PricingCalculator.Domain.Interfaces.Commands;
using System.ComponentModel.DataAnnotations;

namespace PricingCalculator.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController(IServiceCommands _serviceCommands) : ControllerBase
{
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
            if (e is ServiceAlreadyRegisteredException) return Conflict($"Service {request.Name} is already registered");
            Console.WriteLine(e);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}
