using Waracle.HotelBooking.Model;

namespace Waracle.HotelBooking
{
    /// <summary>
    /// Request object for <see cref="AvailableRoomsController.Get()"/>
    /// </summary>
    /// <param name="Name"></param>
    public record AvailableRoomResponse(RoomDisplayProxy Room, DateOnly DateFrom, DateOnly DateTo, int GuestsAmount);
}
