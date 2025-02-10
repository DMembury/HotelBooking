using Waracle.HotelBooking.Domain.Model;

namespace Waracle.HotelBooking.Response
{
    /// <summary>
    /// Response object for <see cref="AvailableRoomsController.Get()"/>
    /// </summary>
    /// <param name="Name"></param>
    public class AvailableRoomsResponse : List<RoomDisplayProxy>
    {
        public AvailableRoomsResponse(IEnumerable<RoomDisplayProxy> toCopy)
            : base(toCopy)
        {
            // Intentionally empty.            
        }

        // Intentionally empty.
    }
}
