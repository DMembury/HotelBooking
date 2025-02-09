namespace Waracle.HotelBooking
{
    /// <summary>
    /// Request object for <see cref="AvailableRoomsController.Get()"/>
    /// </summary>
    /// <param name="Name"></param>
    public record AvailableRoomsRequest(DateOnly DateFrom, DateOnly DateTo, int GuestsAmount);
}
