using ServiceContracts;
using Models.Models;

namespace Services
{
    public class WeatherService : IWeatherService
    {
        private List<CityWeather> _cityWeatherList;

        public WeatherService()
        {
            _cityWeatherList = new List<CityWeather>()
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
        }

        public List<CityWeather> GetWeatherDetails()
        {
            return _cityWeatherList;
        }

        public CityWeather? GetWeatherByCityCode(string CityCode)
        {
            return _cityWeatherList.Where((c) => c.CityUniqueCode == CityCode).FirstOrDefault();
        }
    }
}
