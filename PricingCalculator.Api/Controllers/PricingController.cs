using Microsoft.AspNetCore.Mvc;
using PricingCalculator.Api.Models;

namespace PricingCalculator.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PricingController : ControllerBase
{
    //PricingCalculator pricingCalculator
    public PricingController()
    {
        //_pricingCalculator = pricingCalculator;
    }

    [HttpPost("calculate")]
    public ActionResult<decimal> CalculatePrice([FromBody] PricingRequest request)
    {
        if (request == null)
            return BadRequest("Request cannot be null.");
        try
        {
            //decimal totalPrice = _pricingCalculator.CalculateTotalPrice(request);
            //totalPrice
            return Ok();
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        
    }
}
