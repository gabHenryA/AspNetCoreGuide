using ServiceContracts;
using ServiceContracts.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ConfigurationExercise2.Models;
using Entities;
using Rotativa.AspNetCore;
using ConfigurationExercise2.Filters.ActionFilters;

namespace ConfigurationExercise2.Controllers
{

    [Route("[controller]")]
    public class TradeController : Controller
    {
        private readonly IOptions<TradingOptions> _tradingOptions;
        private readonly IFinnhubService _finnhubService;
        private readonly IConfiguration _configuration;
        private readonly IStockService _stockService;
        private readonly ILogger<TradeController> _logger;

        public TradeController(IOptions<TradingOptions> tradingOptions, IFinnhubService finnhubService, IConfiguration configuration, IStockService stockService, ILogger<TradeController> logger)
        {
            _tradingOptions = tradingOptions;
            _finnhubService = finnhubService;
            _configuration = configuration;
            _stockService = stockService;
            _logger = logger;
        }

        [Route("/")]
        [Route("[action]")]
        [Route("~/[controller]")]
        public async Task<IActionResult> Index(string stockSymbol)
        {
            _logger.LogInformation("In TradeController.Index() action method");
            _logger.LogDebug("stockSymbol: {stockSymbol}", stockSymbol);

            if (string.IsNullOrEmpty(stockSymbol))
                stockSymbol = "MSFT";

            Dictionary<string, object>? responseCompany = await _finnhubService.GetCompanyProfile(_tradingOptions.Value.DefaultStockSymbol ?? stockSymbol);
            Dictionary<string, object>? responseStockPrice = await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol ?? stockSymbol);

            StockTrade stockTrade = new StockTrade()
            {
                StockSymbol = _tradingOptions.Value.DefaultStockSymbol,
                Quantity = _tradingOptions.Value.DefaultOrderQuantity,
                StockName = responseCompany["name"].ToString(),
                Price = Convert.ToDouble(responseStockPrice["c"].ToString())
            };

            ViewBag.FinnhubToken = _configuration["FinnhubToken"];

            return View(stockTrade);
        }


        [Route("[action]")]
        [HttpPost]
        [TypeFilter(typeof(CreateOrderActionFilter))]
        public async Task<IActionResult> BuyOrder(BuyOrderRequest orderRequest)
        {
            BuyOrderResponse buyOrderResponse = await _stockService.CreateBuyOrder(orderRequest);

            return RedirectToAction(nameof(Orders));
        }

        [Route("[action]")]
        [TypeFilter(typeof(CreateOrderActionFilter))]
        public async Task<IActionResult> SellOrder(SellOrderRequest orderRequest)
        {
            SellOrderResponse sellOrderResponse = await _stockService.CreateSellOrder(orderRequest);

            return RedirectToAction("Orders");
        }

        [Route("[action]")]
        public async Task<IActionResult> Orders()
        {
            List<BuyOrderResponse> buyOrderResponses = await _stockService.GetBuyOrders();
            List<SellOrderResponse> sellOrderResponses = await _stockService.GetSellOrders();

            Orders orders = new Orders()
            {
                BuyOrders = buyOrderResponses,
                SellOrders = sellOrderResponses
            };

            return View(orders);
        }

        [Route("OrdersPDF")]
        public async Task<IActionResult> OrdersPDF()
        {
            List<IOrderResponse> orderResponses = new List<IOrderResponse>();

            List<BuyOrderResponse> buyOrderResponses = await _stockService.GetBuyOrders();
            List<SellOrderResponse> sellOrderResponses = await _stockService.GetSellOrders();

            orderResponses.AddRange(buyOrderResponses);
            orderResponses.AddRange(sellOrderResponses);

            orderResponses = orderResponses.OrderByDescending(t => t.DateAndTimeOfOrder).ToList();

            ViewBag.TradingOptions = _tradingOptions;

            return new ViewAsPdf("OrdersPDF", orderResponses, ViewData)
            {
                PageMargins = new Rotativa.AspNetCore.Options.Margins() { Top = 20, Right = 20, Bottom = 20, Left = 20 },
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape
            };
        }
    }
}
