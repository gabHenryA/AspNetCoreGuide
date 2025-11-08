using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.Configuration;
using RepositoryCon;

namespace Services
{
    public class FinnhubService : IFinnhubService
    {
        private readonly IFinnhubRepository _finnhubRepository;

        public FinnhubService(IHttpClientFactory httpClientFactory, IConfiguration configuration, IFinnhubRepository finnhubRepository)
        {
            _finnhubRepository = finnhubRepository;
        }

        public async Task<Dictionary<string, object>?> GetCompanyProfile(string stockSymbol)
        {
            Dictionary<string, object>? companyProfile = await _finnhubRepository.GetCompanyProfile(stockSymbol);
            return companyProfile;
        }

        public async Task<Dictionary<string, object>?> GetStockPriceQuote(string stockSymbol)
        {
            Dictionary<string, object>? stockPriceQuote = await _finnhubRepository.GetStockPriceQuote(stockSymbol);
            return stockPriceQuote;
        }

        public async Task<List<Dictionary<string, string>>?> GetStocks()
        {
            List<Dictionary<string, string>>? stocks = await _finnhubRepository.GetStocks();
            return stocks;
        }

        public async Task<Dictionary<string, object>?> SearchStocks(string stockSymbolToSearch)
        {
            Dictionary<string, object>? stocks = await _finnhubRepository.SearchStocks(stockSymbolToSearch);
            return stocks;
        }
    }
}
