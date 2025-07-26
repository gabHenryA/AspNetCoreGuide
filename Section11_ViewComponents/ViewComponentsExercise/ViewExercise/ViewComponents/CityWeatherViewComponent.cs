using Microsoft.AspNetCore.Mvc;
using ViewExercise.Models;

namespace ViewExercise.ViewComponents
{
    public class CityWeatherViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(CityWeather cityWeather)
        {
            return View("City", cityWeather);
        }
    }
}
