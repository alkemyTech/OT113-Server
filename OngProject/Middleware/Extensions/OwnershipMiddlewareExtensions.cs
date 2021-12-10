using Microsoft.AspNetCore.Builder;

namespace OngProject.Middleware
{
    public static class OwnershipMiddlewareExtensions
    {
        public static IApplicationBuilder UseOwnershipMiddleware(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<OwnershipMiddleware>();
        }
    }

   
}