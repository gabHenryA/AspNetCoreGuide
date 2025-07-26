using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace MiddlewareTest
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareLogin
    {
        private readonly RequestDelegate _next;

        public MiddlewareLogin(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {

            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareLoginExtensions
    {
        public static IApplicationBuilder UseMiddlewareLogin(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareLogin>();
        }
    }
}
