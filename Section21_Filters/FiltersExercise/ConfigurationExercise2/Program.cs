using ConfigurationExercise2;
using Services;
using ServiceContracts;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.Extensions.DependencyInjection;
using Rotativa.AspNetCore;
using RepositoryCon;
using Repositories;
using Serilog;
using Serilog.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Host.ConfigureLogging(loggingProvider =>
//{
//    loggingProvider.ClearProviders();
//    loggingProvider.AddConsole();
//    loggingProvider.AddDebug();
//});

//Serilog
builder.Host.UseSerilog((HostBuilderContext context, IServiceProvider services, LoggerConfiguration loggerConfiguration) => {

    loggerConfiguration
    .ReadFrom.Configuration(context.Configuration) //read configuration settings from built-in IConfiguration
    .ReadFrom.Services(services); //read out current app's services and make them available to serilog
});

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

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.RequestProperties | Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.ResponsePropertiesAndHeaders;
});

var app = builder.Build();

app.UseSerilogRequestLogging();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

if (builder.Environment.IsEnvironment("Test") == false)
    Rotativa.AspNetCore.RotativaConfiguration.Setup("wwwroot", wkhtmltopdfRelativePath: "Rotativa");

app.UseHttpLogging();

app.UseStaticFiles();
app.MapControllers();
app.UseRouting();

app.Run();

public partial class Program { }