using EarthGuide.Core.Domain;
using EarthGuide.Core.Interfaces;

namespace EarthGuide.API.Endpoints
{
    public static class RestaurantEndpoints
    {
        public static void UseRestaurantEndpoints(this WebApplication app)
        {
            app.MapGet("/restaurants/", GetAll);
        }

        private static async Task<IResult> GetAll(
            ILoggerFactory loggerFactory,
            IRestaurantRepository repo) 
        {
            ILogger logger = loggerFactory.CreateLogger("Restaurant endpoints");
            logger.LogInformation("Returning all of the restaurants");
            IEnumerable<Restaurant> rest = await repo.GetAll();
            return Results.Ok(rest);
        }
    }
}
