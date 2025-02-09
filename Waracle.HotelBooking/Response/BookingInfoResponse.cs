using System.Text.Json.Serialization;
using Waracle.HotelBooking.Data.Models;
using Waracle.HotelBooking.Model;

namespace Waracle.HotelBooking.Response
{
    /// <summary>
    /// Response object for <see cref="AvailableRoomsController.Get()"/>
    /// </summary>
    /// <param name="Name"></param>
    public record BookingInfoResponse([property: JsonIgnore]Booking Booking)
    {
        public HotelDisplayProxy Hotel => new(this.Booking.Room?.Hotel ?? new Hotel());

        public RoomDisplayProxy Room => new(this.Booking.Room ?? new Room());

        public string LeadGuestName => this.Booking.GuestName;

        public string LeadGuestTelephone => this.Booking.GuestTelNo;

        public DateOnly DateFrom => this.Booking.DateStart;

        public DateOnly DateTo => this.Booking.DateEnd;
    }
}
