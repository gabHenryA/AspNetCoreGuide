using ConfigurationExercise2;
using ConfigurationExercise2.Service;
using ConfigurationExercise2.ServiceContracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IFinnhubService, FinnhubService>();
builder.Services.Configure<TradingOptions>
    (builder.Configuration.GetSection("TradingOptions"));

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.Run();
