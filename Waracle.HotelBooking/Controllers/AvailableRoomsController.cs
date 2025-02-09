using Microsoft.AspNetCore.Mvc;
using Waracle.HotelBooking.Data.Models;
using Waracle.HotelBooking.Response;

namespace Waracle.HotelBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvailableRoomsController : ControllerBase
    {
        public AvailableRoomsController
        (
            ILogger<AvailableRoomsController> logger,
            HotelBookingContext dbContext
        )
        {
            Logger = logger;
            DbContext = dbContext;
        }

        public ILogger<AvailableRoomsController> Logger { get; }
        public HotelBookingContext DbContext { get; }

        /// <summary>
        /// Find available rooms for the given number of guests for the given date range.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet(Name = "FindAvailableRooms")]
        //[SwaggerOperation("Find a hotel by providing a part of its name.")]
        //[SwaggerResponse(200, "A matching hotel was successfully found.", typeof(HotelDisplayProxy))]
        //[SwaggerResponse(400, "The search term is absent or empty.", typeof(string))]
        //[SwaggerResponse(404, "No matching hotel was found.", typeof(string))]
        public async Task<ActionResult<AvailableRoomsResponse>> Get([FromQuery]AvailableRoomsRequest request)
        {
            // DM 2025-02-09 TODO :: Stub
            throw new NotImplementedException();
        }
    }
}
