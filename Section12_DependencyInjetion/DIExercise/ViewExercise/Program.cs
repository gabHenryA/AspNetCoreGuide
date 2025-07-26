using Services;
using ServiceContracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
