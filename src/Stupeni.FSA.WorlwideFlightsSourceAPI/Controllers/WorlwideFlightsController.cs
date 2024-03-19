using Microsoft.AspNetCore.Mvc;

namespace Stupeni.FSA.WorlwideFlightsSourceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorlwideFlightsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using StreamReader r = new StreamReader("flights.json");
            string json = await r.ReadToEndAsync();

            return Ok(json);
        }
    }
}