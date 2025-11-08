namespace ServiceContracts
{
    public interface IFinnhubService
    {
        Task<Dictionary<string, object>?> GetCompanyProfile(string stockSimbol);
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSimbol);
        Task<List<Dictionary<string, string>>?> GetStocks();
        Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch);
    }
}
