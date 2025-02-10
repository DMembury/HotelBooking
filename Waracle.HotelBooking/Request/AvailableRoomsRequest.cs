namespace Waracle.HotelBooking
{
    /// <summary>
    /// Request object for <see cref="AvailableRoomsController.Get()"/>
    /// </summary>
    /// <param name="Name"></param>
    public record AvailableRoomsRequest(int HotelId, DateOnly DateFrom, DateOnly DateTo, int GuestsAmount);
}
