using Microsoft.AspNetCore.Builder;

namespace WeatherService.API
{
    public static class MiddleWare
    {
        public static IApplicationBuilder UseMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestHandler>();
        }
    }
}
