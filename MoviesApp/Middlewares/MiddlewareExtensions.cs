using Microsoft.AspNetCore.Builder;

namespace MoviesApp.Middlewares
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseActorControllerLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ActorControllerLoggerMiddleware>();
        }
    }
}
