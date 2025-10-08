using ConfigurationExercise2;
using Services;
using ServiceContracts;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;
using RepositoryCon;
using Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IFinnhubService, FinnhubService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<IStockRepositories, StockRepository>();
builder.Services.AddScoped<IFinnhubRepository, FinnhubRepository>();
builder.Services.Configure<TradingOptions>
    (builder.Configuration.GetSection("TradingOptions"));
builder.Services.AddDbContext<StockMarketDbContext>(
    options =>
    {
        options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]);
    });

builder.Services.AddHttpClient();

var app = builder.Build();

if (builder.Environment.IsEnvironment("Test") == false)
    Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.Run();

public partial class Program { }