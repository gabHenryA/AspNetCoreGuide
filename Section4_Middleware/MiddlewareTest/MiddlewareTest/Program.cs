using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddlewareLogin();

app.Run();

public class MiddlewareLogin
{
    private readonly RequestDelegate _next;

    public MiddlewareLogin(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        StreamReader reader = new StreamReader(context.Request.Body);
        string body = await reader.ReadToEndAsync();

        Dictionary<string, StringValues> queryDict = Microsoft.AspNetCore.WebUtilities.QueryHelpers.ParseQuery(body);

        if(context.Request.Method == "POST" && context.Request.Path == "/")
        {
            context.Response.StatusCode = 200;

            if(!queryDict.ContainsKey("email"))
            {
                if (context.Response.StatusCode == 200) context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Input invalid for 'email'");
            }

            if (!queryDict.ContainsKey("password"))
            {
                if (context.Response.StatusCode == 200) context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Input invalid for 'password'");
            }

            if(queryDict["email"] == "admin@example.com" && queryDict["password"] == "admin1234")
            {
                await context.Response.WriteAsync("Successful login");
            }
            else
            {
                if (queryDict.ContainsKey("email") && queryDict.ContainsKey("password"))
                {
                    if (context.Response.StatusCode == 200) context.Response.StatusCode = 400;
                    await context.Response.WriteAsync("Invalid login");
                }
            }
        }

        if(context.Request.Method == "GET" && context.Request.Path == "/")
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync("No response");
        }

        await _next(context);
    }
}

public static class MiddlewareLoginExtensions
{
    public static IApplicationBuilder UseMiddlewareLogin(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MiddlewareLogin>();
    }
}