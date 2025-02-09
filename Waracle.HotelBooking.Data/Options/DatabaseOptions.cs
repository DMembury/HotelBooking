namespace Waracle.HotelBooking.Data.Options
{
    using System.ComponentModel.DataAnnotations;

    public class DatabaseOptions
    {
        public const string Path = "Database";

        [Required]
        [MinLength(1)]
        public string ConnectionString { get; set; } = string.Empty;
    }
}
