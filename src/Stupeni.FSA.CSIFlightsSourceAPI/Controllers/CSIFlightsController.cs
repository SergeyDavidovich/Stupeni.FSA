using Microsoft.AspNetCore.Mvc;

namespace Stupeni.FSA.CSIFlightsSourceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CSIFlightsController : ControllerBase
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