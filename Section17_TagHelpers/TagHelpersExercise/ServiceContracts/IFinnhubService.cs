namespace ServiceContracts
{
    public interface IFinnhubService
    {
        Task<Dictionary<string, object>?> GetCompanyProfile(string stockSimbol);
        Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSimbol);
    }
}
