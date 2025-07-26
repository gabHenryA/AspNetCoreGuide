var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Dictionary<int, string> countries = new Dictionary<int, string>
{
    {1, "United States"},
    {2, "Canada"},
    {3, "United Kingdom"},
    {4, "India"},
    {5, "Japan"},
};

app.UseRouting();

app.UseEndpoints((endpoints) =>
{
    endpoints.MapGet("/countries", async (context) =>
    {
        for(int i = 1; i <= countries.Count; i++)
        {
            await context.Response.WriteAsync($"{i}, {countries[i]}\n");
        }
    });

    endpoints.MapGet("/countries/{countryID:int}", async (context) =>
    {
        int countryId = Convert.ToInt32(context.Request.RouteValues["countryID"]);

        if(countryId > 100)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsync("The CountryID should be between 1 and 100");
        }
        else if(countryId < 1 || countryId > countries.Count)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("No country");
        }
        else
        {
            await context.Response.WriteAsync($"{countries[countryId]}");
        }
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync($"Request received at {context.Request.Path}");
});

app.Run();
