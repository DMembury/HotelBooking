using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection.Metadata.Ecma335;
using Waracle.HotelBooking.Data.Models;
using Waracle.HotelBooking.Domain.Model;
using Waracle.HotelBooking.Properties;
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
        [SwaggerOperation("Find available rooms for the given number of guests for the given date range.")]
        [SwaggerResponse(200, "One or more available rooms were successfully found.", typeof(AvailableRoomsResponse))]
        [SwaggerResponse(400, "The date range given was not valid.", typeof(string))]
        [SwaggerResponse(404, "No available rooms were found in the given hotel for the given date range, or the required occupancy.", typeof(string))]
        public async Task<ActionResult<AvailableRoomsResponse>> GetAsync([FromQuery]AvailableRoomsRequest request)
        {
            // Request validation
            // Lifted from BookRoomController - should be centralised, DRY.
            if (request.DateFrom < DateOnly.FromDateTime(DateTime.Now))
            {
                return BadRequest(Resources.BookRoom_Post_BadRequest_PastBooking);
            }

            if (request.DateTo < request.DateFrom)
            {
                return BadRequest(Resources.BookRoom_Post_BadRequest_BadBookingEnd);
            }

            // Check hotel exists.
            var hotel = await this.DbContext.Hotels
                .SingleOrDefaultAsync(hotel => hotel.Id == request.HotelId).ConfigureAwait(false);

            if (hotel == default)
            {
                return NotFound(Resources.AvailableRooms_Get_BadRequest_BadHotel);
            }

            // This is a very rough sketch for a solution and is nowhere close to optimal.
            // Avenues include holding optimised SQL in a repository class, using an SP or finding an additional efficiency in the approach itself.
            // E.g. consider filtering bookings to pick only overlapping (like in BookRoomController) to avoid pulling all bookings from DB every time.

            // Pick all bookings for eligible rooms in given hotel.
            var allRelevantBookingsForHotel = await this.DbContext.Bookings
                .Include(booking => booking.Room)
                .Include(booking => booking.Room.Hotel)
                .Include(booking => booking.Room.Type)
                .Where(booking => booking.Room.Hotel.Id == request.HotelId) // Enforce per-hotel search
                .Where(booking => booking.Room.Type.Occupancy >= request.GuestsAmount) // Enforce max occupancy
                .ToListAsync();

            var roomBookings = allRelevantBookingsForHotel.GroupBy(booking => booking.Room);

            var availableRooms = await this.DbContext.Rooms
                .Include(room => room.Type)
                .Where(room => room.HotelId == request.HotelId)
                .Where(room => room.Type.Occupancy >= request.GuestsAmount) // Enforce max occupancy
                .ToListAsync();

            // If any bookings for a room conflict with the request, then remove that room from the return list.
            // This implementation makes use of the 6-room limit - bad performer for larger room counts.
            foreach (var roomBooking in roomBookings)
            {
                if (roomBooking.Any(booking => DoesBookingCollide(booking, request.DateFrom, request.DateTo)))
                {
                    availableRooms.RemoveAll(room => room.Id == roomBooking.Key.Id);
                }
            }

            if (availableRooms.Count <= 0)
            {
                return NotFound(Resources.AvailableRooms_Get_NotFound_NoAvailableRooms);
            }

            return new AvailableRoomsResponse(availableRooms.Select(room => new RoomDisplayProxy(room)));
        }

        /// <summary>
        /// Checks if the booking conflicts with the given date range.
        /// </summary>
        /// <returns>True only if the booking conflicts with the given date range.</returns>
        private static bool DoesBookingCollide(Booking booking, DateOnly dateFrom, DateOnly dateTo)
        {
            // Logic lifted from BookRoomController - should be centralised, DRY.
            return
            (booking.DateStart <= dateFrom && booking.DateEnd >= dateFrom && booking.DateEnd <= dateTo)
            || (booking.DateStart >= dateFrom && booking.DateStart <= dateTo && booking.DateEnd >= dateTo)
            || (booking.DateStart <= dateFrom && booking.DateEnd >= dateTo)
            || (booking.DateStart >= dateFrom && booking.DateEnd <= dateTo);
        }
    }
}
