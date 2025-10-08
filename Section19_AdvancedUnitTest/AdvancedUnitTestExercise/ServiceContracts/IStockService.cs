using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IStockService
    {
        Task<BuyOrderResponse> CreateBuyOrder(BuyOrderRequest? buyOrderRequest);
        Task<SellOrderResponse> CreateSellOrder(SellOrderRequest? SellOrderRequest);
        Task<List<BuyOrderResponse>> GetBuyOrders();
        Task<List<SellOrderResponse>> GetSellOrders();
    }
}
