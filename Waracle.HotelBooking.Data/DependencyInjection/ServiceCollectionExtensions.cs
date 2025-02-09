namespace Waracle.HotelBooking.Data.DependencyInjection
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;
    using Waracle.HotelBooking.Data.Models;
    using Waracle.HotelBooking.Data.Options;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            _ = serviceCollection.AddDbContext<HotelBookingContext>(ConfigureDatabaseOptionsBuilder);

            _ = serviceCollection.AddOptions<DatabaseOptions>()
                .Bind(configuration.GetSection(DatabaseOptions.Path));

            return serviceCollection;
        }

        private static void ConfigureDatabaseOptionsBuilder(IServiceProvider services, DbContextOptionsBuilder builder)
        {
            var options = services.GetRequiredService<IOptionsSnapshot<DatabaseOptions>>();
            builder.UseSqlServer(options.Value.ConnectionString);
        }
    }
}
