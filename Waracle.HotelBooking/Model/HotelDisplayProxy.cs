using System.Text.Json.Serialization;
using Waracle.HotelBooking.Data.Models;

namespace Waracle.HotelBooking.Model
{
    /// <summary>
    /// Proxy over <see cref="Hotel"/> to prevent EF-specific properties being serialised in API output.
    /// </summary>
    public record HotelDisplayProxy([property:JsonIgnore]Hotel Hotel)
    {
        public int Id => this.Hotel.Id;

        public string Name => this.Hotel.Name;

        public string Address => this.Hotel.Address;
    }
}
