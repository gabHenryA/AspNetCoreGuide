using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace ViewExercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [Route("/")]
        public IActionResult Index()
        {
            var cityWeatherList = _weatherService.GetWeatherDetails();
            ViewBag.cities = cityWeatherList;

            return View(cityWeatherList);
        }

        [Route("/weather/{cityCode}")]
        public IActionResult Details(string cityCode)
        {
            if(string.IsNullOrEmpty(cityCode))
            {
                return BadRequest("Enter a city code");
            }

            var cityWeather = _weatherService.GetWeatherByCityCode(cityCode);

            if (cityWeather == null)
            {
                return NotFound("This city code does not exist");
            }

            return View(cityWeather);
        }
    }
}
