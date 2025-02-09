namespace Waracle.HotelBooking.Request
{
    /// <summary>
    /// Request object for <see cref="HotelInfoController.Get()"/>
    /// </summary>
    /// <param name="Name"></param>
    public record HotelInfoRequest(string Name);
}
