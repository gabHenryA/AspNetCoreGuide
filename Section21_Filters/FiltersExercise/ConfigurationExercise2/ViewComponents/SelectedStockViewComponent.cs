using Microsoft.AspNetCore.Mvc;
using ServiceContracts;

namespace ConfigurationExercise2.ViewComponents
{
    public class SelectedStockViewComponent : ViewComponent
    {
        private readonly IFinnhubService _finnhubService; 

        public SelectedStockViewComponent(IFinnhubService finnhubService)
        {
            _finnhubService = finnhubService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? stockSymbol)
        {
            Dictionary<string, object>? companyProfile = null;

            if(stockSymbol != null)
            {
                companyProfile = await _finnhubService.GetCompanyProfile(stockSymbol);
                var stockPrice = await _finnhubService.GetStockPriceQuote(stockSymbol);

                if(stockPrice != null && companyProfile != null)
                {
                    companyProfile.Add("price", stockPrice["c"]);
                }
            }

            if(companyProfile != null && companyProfile.ContainsKey("logo"))
            {
                return View(companyProfile);
            }
            else
            {
                return Content("");
            }
        }
    }
}
