using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OngProject.Middleware
{
    public class RoutesAdminMiddleware
    {
        private readonly RequestDelegate _next;

        public RoutesAdminMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
        
        List<string> methods = new List<string>();
        methods.Add("put"); 
//      methods.Add("post");
        methods.Add("delete");

        List<string> paths = new List<string>();
        paths.Add("/activities");
        paths.Add("/categories");
        paths.Add("/comments");
//      paths.Add("/contacts");
//      paths.Add("/members");
        paths.Add("/news");
        paths.Add("/organization");
//      paths.Add("/roles");
//      paths.Add("/slides");
//      paths.Add("/testimonials");
//      paths.Add("/users");

        var path = context.Request.Path;
        var method = context.Request.Method;

        if (methods.Contains(method.ToLower()) && paths.Contains(path.ToString().ToLower()))
            {
                if (!context.User.IsInRole("Admin"))
                {
                    context.Response.StatusCode = 401;
                }
                else
                {
                    await _next.Invoke(context);
                }
            }
            else
            {
                await _next.Invoke(context);
            }

            await _next(context);

        }

    }
}