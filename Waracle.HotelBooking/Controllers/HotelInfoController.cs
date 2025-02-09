using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waracle.HotelBooking.Data.Models;
using Waracle.HotelBooking.Properties;
using Swashbuckle.AspNetCore.Annotations;
using Waracle.HotelBooking.Request;
using Waracle.HotelBooking.Model;

namespace Waracle.HotelBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotelInfoController : ControllerBase
    {
        public HotelInfoController
        (
            ILogger<HotelInfoController> logger,
            HotelBookingContext dbContext
        )
        {
            Logger = logger;
            DbContext = dbContext;
        }

        public ILogger<HotelInfoController> Logger { get; }
        public HotelBookingContext DbContext { get; }

        /// <summary>
        /// Find a hotel by providing a part of its name.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet(Name = "FindHotel")]
        [SwaggerOperation("Find a hotel by providing a part of its name.")]
        [SwaggerResponse(200, "A matching hotel was successfully found.", typeof(HotelDisplayProxy))]
        [SwaggerResponse(400, "The search term is absent or empty.", typeof(string))]
        [SwaggerResponse(404, "No matching hotel was found.", typeof(string))]
        public async Task<ActionResult<HotelDisplayProxy>> Get([FromQuery]HotelInfoRequest request)
        {
            var hotelName = request.Name;

            if (string.IsNullOrWhiteSpace(hotelName))
            {
                return BadRequest(Resources.HotelInfo_Get_BadRequest_EmptyName);
            }

            var hotelsContainingArgument = await this.DbContext.Hotels
                .FirstOrDefaultAsync(hotel => hotel.Name.ToLower().Contains(hotelName.ToLower())).ConfigureAwait(false);

            if (hotelsContainingArgument == default)
            {
                return NotFound(Resources.HotelInfo_Get_NotFound_NoDbMatch);
            }
            else
            {
                return new HotelDisplayProxy(hotelsContainingArgument);
            }
        }
    }
}
