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
    public class BookRoomController : ControllerBase
    {
        public BookRoomController
        (
            ILogger<BookRoomController> logger,
            HotelBookingContext dbContext
        )
        {
            Logger = logger;
            DbContext = dbContext;
        }

        public ILogger<BookRoomController> Logger { get; }
        public HotelBookingContext DbContext { get; }

        /// <summary>
        /// Book a hotel room between the given dates for the given guest.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(Name = "BookRoom")]
        [SwaggerOperation("Book a hotel room between the given dates for the given guest.")]
        [SwaggerResponse(200, "A matching hotel was successfully found.", typeof(BookingDisplayProxy))]
        [SwaggerResponse(400, "The request was not valid for the current room and booking status.", typeof(string))]
        [SwaggerResponse(404, "The given room was not found.", typeof(string))]
        public async Task<ActionResult<BookingDisplayProxy>> Post([FromBody]BookRoomRequest request)
        {
            // Verify first
            // Perform date checks first to save a DB call if these are wrong.
            if (request.DateFrom < DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest(Resources.BookRoom_Post_BadRequest_PastBooking);
            }

            if 
            (
                request.DateTo < DateOnly.FromDateTime(DateTime.Now)
                || request.DateTo < request.DateFrom
            )
            {
                return BadRequest(Resources.BookRoom_Post_BadRequest_BadBookingEnd);
            }

            var room = await this.DbContext.Rooms
                .SingleOrDefaultAsync(room => room.Id == request.RoomId).ConfigureAwait(false);

            if (room == default)
            {
                return NotFound(Resources.BookRoom_Post_NotFound_BadRoom);
            }

            // Verification done, book it.
            var booking = new Booking
            {
                RoomId = room.Id,
                DateStart = request.DateFrom,
                DateEnd = request.DateTo,
                GuestName = request.LeadGuestName,
                GuestTelNo = request.LeadGuestTelNumber
            };

            this.DbContext.Bookings.Add(booking);
            try
            {
                await this.DbContext.SaveChangesAsync();
            }
            // Prevent exception stack falling out to user for most-expected failure case.
            catch (DbUpdateException ex)
            {
                this.Logger.LogError(ex, "Error adding new booking");
                return StatusCode(500, Resources.BookRoom_Post_ServerError_BookingFailed);
            }

            return new BookingDisplayProxy(booking);
        }
    }
}
