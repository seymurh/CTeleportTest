using System;
using System.Threading.Tasks;
using AmmaDeyyus.QueryHandlers.Common;
using Microsoft.AspNetCore.Mvc;
using TeleportServices.Models;

namespace AmmaDeyyus.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirportsController : ControllerBase
    {
        private readonly IQueryHandler queryHandler;

        public AirportsController(IQueryHandler queryHandler)
        {
            if (queryHandler == null) throw new ArgumentNullException(nameof(queryHandler));

            this.queryHandler = queryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetDistance([FromQuery] GetAirportDistanceRequest getAirportDistanceRequest)
        {
            var result = await queryHandler.Handle<GetAirportDistanceRequest, double>(getAirportDistanceRequest);
            return Ok(result);
        }
    }
}