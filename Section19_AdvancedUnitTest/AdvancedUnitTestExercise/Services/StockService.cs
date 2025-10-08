using ServiceContracts;
using ServiceContracts.DTO;
using Services.Helpers;
using Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RepositoryCon;

namespace Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepositories _stockRepositories;

        public StockService(IStockRepositories stockRepositories)
        {
            _stockRepositories = stockRepositories;
        }

        public async Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {
            if(buyOrderRequest == null)
            {
                throw new ArgumentNullException(nameof(buyOrderRequest));
            }

            ValidationHelper.ModelValidation(buyOrderRequest);

            BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();

            buyOrder.BuyOrderID = Guid.NewGuid();

            BuyOrder buyOrderFromRepository = await _stockRepositories.CreateBuyOrder(buyOrder);

            //_db.BuyOrders.Add(buyOrder);
            //await _db.SaveChangesAsync();

            return buyOrder.ToBuyOrderResponse();
        }

        public async Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if (sellOrderRequest == null)
            {
                throw new ArgumentNullException(nameof(sellOrderRequest));
            }

            ValidationHelper.ModelValidation(sellOrderRequest);

            SellOrder sellOrder = sellOrderRequest.ToSellOrder();

            sellOrder.SellOrderID = Guid.NewGuid();

            SellOrder sellOrderFromRepository = await _stockRepositories.CreateSellOrder(sellOrder);

            //_db.SellOrders.Add(sellOrder);
            //await _db.SaveChangesAsync();

            return sellOrder.ToSellOrderResponse();
        }

        public async Task<List<BuyOrderResponse>> GetBuyOrders()
        {
            List<BuyOrder> buyOrders = await _stockRepositories.GetBuyOrders();

            return buyOrders.Select(temp => temp.ToBuyOrderResponse()).ToList();
        }

        public async Task<List<SellOrderResponse>> GetSellOrders()
        {
            List<SellOrder> sellOrders = await _stockRepositories.GetSellOrders();

            return sellOrders.Select(temp => temp.ToSellOrderResponse()).ToList();
        }
    }
}
