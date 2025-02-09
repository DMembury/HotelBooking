using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Waracle.HotelBooking.Data.Models;
using Waracle.HotelBooking.Properties;
using Swashbuckle.AspNetCore.Annotations;
using Waracle.HotelBooking.Request;
using Waracle.HotelBooking.Model;
using Waracle.HotelBooking.Response;

namespace Waracle.HotelBooking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingInfoController : ControllerBase
    {
        public BookingInfoController
        (
            ILogger<BookingInfoController> logger,
            HotelBookingContext dbContext
        )
        {
            Logger = logger;
            DbContext = dbContext;
        }

        public ILogger<BookingInfoController> Logger { get; }
        public HotelBookingContext DbContext { get; }

        /// <summary>
        /// Get information about a booking given its unique ID.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet(Name = "BookingInfo")]
        [SwaggerOperation("Get information about a booking given its unique ID.")]
        [SwaggerResponse(200, "A matching booking was successfully found.", typeof(BookingInfoResponse))]
        [SwaggerResponse(404, "No matching booking was found.", typeof(string))]
        public async Task<ActionResult<BookingInfoResponse>> Get([FromQuery]string bookingId)
        {
            var booking = await this.DbContext.Bookings
                .Include(booking => booking.Room)
                .Include(booking => booking.Room.Hotel)
                .Include(booking => booking.Room.Type)
                .SingleOrDefaultAsync(booking => booking.Id.ToString().ToLower() == bookingId.ToLower());

            if (booking == default)
            { 
                return NotFound(Resources.BookingInfo_Get_NotFound_BadId);
            }

            return new BookingInfoResponse(booking);
        }
    }
}
