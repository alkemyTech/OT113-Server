using Microsoft.AspNetCore.Builder;

namespace OngProject.Middleware
{
    public static class RoutesAdminMiddlewareExtensions
    {
         public static IApplicationBuilder UseRoutesAdminMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RoutesAdminMiddleware>();
        }
    }
}