using Microsoft.AspNetCore.Mvc;
using ViewExercise.Models;

namespace ViewExercise.Controllers
{
    public class HomeController : Controller
    {
        List<CityWeather> cityWeatherList = new List<CityWeather>()
        {
            new CityWeather()
            {
                CityUniqueCode = "LDN", CityName = "London", DateAndTime = Convert.ToDateTime("2030-01-01 8:00"),  TemperatureFahrenheint = 33
            },
            new CityWeather()
            {
                CityUniqueCode = "NYC", CityName = "New York", DateAndTime = Convert.ToDateTime("2030-01-01 3:00"),  TemperatureFahrenheint = 60
            },
            new CityWeather()
            {
                CityUniqueCode = "PAR", CityName = "Paris", DateAndTime = Convert.ToDateTime("2030-01-01 9:00"),  TemperatureFahrenheint = 82

            }
        };

        [Route("/")]
        public IActionResult Index()
        {
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

            CityWeather? cityWeather = cityWeatherList.Where((c) => c.CityUniqueCode == cityCode).FirstOrDefault();

            if (cityWeather == null)
            {
                return NotFound("This city code does not exist");
            }

            return View(cityWeather);
        }
    }
}
