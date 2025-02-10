using System.Text.Json.Serialization;
using Waracle.HotelBooking.Data.Models;

namespace Waracle.HotelBooking.Domain.Model
{
    /// <summary>
    /// Proxy over <see cref="Room"/> to prevent EF-specific properties being serialised in API output.
    /// </summary>
    public record RoomDisplayProxy([property:JsonIgnore]Room Room)
    {
        public int Id => this.Room.Id;

        public string Name => this.Room.Name;

        public string Type => this.Room.Type.Name;
    }
}
