using System.Text.Json.Serialization;
using Waracle.HotelBooking.Data.Models;

namespace Waracle.HotelBooking.Model
{
    /// <summary>
    /// Proxy over <see cref="Booking"/> to tailor exact properties being serialised in API output.
    /// </summary>
    public record BookingDisplayProxy([property:JsonIgnore]Booking Booking)
    {
        public string Id => this.Booking.Id.ToString();
    }
}
