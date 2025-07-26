using ConfigurationExample;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.Configure<WeatherApiOptions>
    (builder.Configuration.GetSection("weather"));

//Load MyOwnConfig.json
builder.Host.ConfigureAppConfiguration
    ((hostingContext, config) =>
    {
        config.AddJsonFile("MyOwnConfig.json", optional:true, reloadOnChange:true);
    });

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.Run();
