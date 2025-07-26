using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        //private readonly IConfiguration _configuration;
        private readonly WeatherApiOptions _options;

        public HomeController(/* IConfiguration configuration */ IOptions<WeatherApiOptions> weatherApiOptions)
        {
            //_configuration = configuration;
            _options = weatherApiOptions.Value;
        }
        
        [Route("/")]
        public IActionResult Index()
        {
            //ViewBag.ClientID = _configuration["weatherapi:ClientID"];
            //ViewBag.ClientSecret = _configuration.GetValue("weatherapi", "the default client secret");

            //IConfigurationSection weatherApiSection = _configuration.GetSection("weather");

            //ViewBag.ClientID = weatherApiSection["ClientID"];
            //ViewBag.ClientSecret = weatherApiSection["ClientSecret"];


            // Get: Loads configuration values into a new Options object
            //WeatherApiOptions options = _configuration.GetSection("weatherapi").Get<WeatherApiOptions>();

            // Bind: Loads configuration values inta a existing object
            //WeatherApiOptions options = new WeatherApiOptions();
            //_configuration.GetSection("weather").Bind(options);

            //ViewBag.ClientID = options.ClientID;
            //ViewBag.ClientSecret = options.ClientSecret;

            ViewBag.ClientID = _options.ClientID;
            ViewBag.ClientSecret = _options.ClientSecret;

            return View();
        }
    }
}
