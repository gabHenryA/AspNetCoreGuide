using ConfigurationExercise2;
using Services;
using ServiceContracts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IFinnhubService, FinnhubService>();
builder.Services.AddSingleton<IStockService, StockService>();
builder.Services.Configure<TradingOptions>
    (builder.Configuration.GetSection("TradingOptions"));

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.Run();
