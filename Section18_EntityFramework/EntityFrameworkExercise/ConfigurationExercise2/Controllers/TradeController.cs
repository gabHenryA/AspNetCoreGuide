using ServiceContracts;
using ServiceContracts.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ConfigurationExercise2.Models;
using Entities;
using Rotativa.AspNetCore;

namespace ConfigurationExercise2.Controllers
{

    [Route("[controller]")]
    public class TradeController : Controller
    {
        private readonly IOptions<TradingOptions> _tradingOptions;
        private readonly IFinnhubService _finnhubService;
        private readonly IConfiguration _configuration;
        private readonly IStockService _stockService;

        public TradeController(IOptions<TradingOptions> tradingOptions, IFinnhubService finnhubService, IConfiguration configuration, IStockService stockService)
        {
            _tradingOptions = tradingOptions;
            _finnhubService = finnhubService;
            _configuration = configuration;
            _stockService = stockService;
        }

        [Route("/")]
        [Route("[action]")]
        [Route("~/[controller]")]
        public async Task<IActionResult> Index()
        {
            Dictionary<string, object>? responseCompany = await _finnhubService.GetCompanyProfile(_tradingOptions.Value.DefaultStockSymbol);
            Dictionary<string, object>? responseStockPrice = await _finnhubService.GetStockPriceQuote(_tradingOptions.Value.DefaultStockSymbol);

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
        public async Task<IActionResult> BuyOrder(BuyOrderRequest buyOrderRequest)
        {
            buyOrderRequest.DateAndTimeOfOrder = DateTime.Now;

            ModelState.Clear();
            TryValidateModel(buyOrderRequest);
            
            if(!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                StockTrade stockTrade = new StockTrade() { StockName = buyOrderRequest.StockName, Quantity = buyOrderRequest.Quantity, StockSymbol = buyOrderRequest.StockSymbol };
                return View("Index", stockTrade);
            }

            BuyOrderResponse buyOrderResponse = await _stockService.CreateBuyOrder(buyOrderRequest);

            return RedirectToAction(nameof(Orders));
        }

        [Route("[action]")]
        public async Task<IActionResult> SellOrder(SellOrderRequest sellOrderRequest)
        {
            sellOrderRequest.DateAndTimeOfOrder = DateTime.Now;

            ModelState.Clear();
            TryValidateModel(sellOrderRequest);

            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                StockTrade stockTrade = new StockTrade() { StockName = sellOrderRequest.StockName, Quantity = sellOrderRequest.Quantity, StockSymbol = sellOrderRequest.StockSymbol };
                return View("Index", stockTrade);
            }

            SellOrderResponse sellOrderResponse = await _stockService.CreateSellOrder(sellOrderRequest);

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
