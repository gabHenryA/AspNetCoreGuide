using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ServiceContracts;
using ConfigurationExercise2.Models;

namespace ConfigurationExercise2.Controllers
{
    [Route("[controller]")]
    public class StocksController : Controller
    {
        private readonly IOptions<TradingOptions> _tradingOptions;
        private readonly IFinnhubService _finnhubService;

        public StocksController(IOptions<TradingOptions> tradingOptions, IFinnhubService finnhubService)
        {
            _tradingOptions = tradingOptions;
            _finnhubService = finnhubService;
        }

        
        [Route("[action]/{stock?}")]
        [Route("~/[action]/{stock?}")]
        public async Task<IActionResult> Explore(string? stock, bool showAll = false)
        {
            List<Dictionary<string, string>>? stocksDictionary = await _finnhubService.GetStocks();
            List<Stock> stocks = new List<Stock>();

            if(stocksDictionary != null)
            {
                if(!showAll && _tradingOptions.Value.Top25PopularStocks != null)
                {
                    string[]? top25List = _tradingOptions.Value.Top25PopularStocks.Split(',');

                    if(top25List != null)
                    {
                        stocksDictionary = stocksDictionary.Where(temp => top25List.Contains(Convert.ToString(temp["symbol"]))).ToList();
                    }
                }

                stocks = stocksDictionary.Select(temp => new Stock() { StockName = Convert.ToString(temp["description"]), StockSymbol = Convert.ToString(temp["symbol"]) }).ToList();

            }

            ViewBag.stock = stock;
            return View(stocks);
        }
    }
}
