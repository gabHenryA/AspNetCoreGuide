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
        private readonly ILogger<StocksController> _logger;

        public StocksController(IOptions<TradingOptions> tradingOptions, IFinnhubService finnhubService, ILogger<StocksController> logger)
        {
            _tradingOptions = tradingOptions;
            _finnhubService = finnhubService;
            _logger = logger;
        }

        
        [Route("[action]/{stock?}")]
        [Route("~/[action]/{stock?}")]
        public async Task<IActionResult> Explore(string? stock, bool showAll = false)
        {
            _logger.LogInformation("In StocksController.Explore() action method");
            _logger.LogDebug("stock: {stock}, showAll: {showAll}", stock, showAll);

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
