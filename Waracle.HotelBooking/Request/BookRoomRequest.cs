namespace Waracle.HotelBooking.Request
{
    /// <summary>
    /// Request object for <see cref="BookRoomController.Get()"/>
    /// </summary>
    /// <param name="Name"></param>
    public record BookRoomRequest(int RoomId, DateOnly DateFrom, DateOnly DateTo, string LeadGuestName, string LeadGuestTelNumber, int GuestsAmount);
}
