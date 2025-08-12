using ServiceContracts.DTO;

namespace ServiceContracts
{
    public interface IStockService
    {
        BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest);
        SellOrderResponse CreateSellOrder(SellOrderRequest? SellOrderRequest);
        List<BuyOrderResponse> GetBuyOrders();
        List<SellOrderResponse> GetSellOrders();
    }
}
