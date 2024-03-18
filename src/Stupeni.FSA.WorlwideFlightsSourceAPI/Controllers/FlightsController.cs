﻿using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Stupeni.FSA.WorlwideFlightsSourceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        // GET: api/<FlightsController>
        [HttpGet]
        public IActionResult Get()
        {
            using StreamReader r = new StreamReader("flights.json");
            string json = r.ReadToEnd();

            return Ok(json);
        }
    }
}
