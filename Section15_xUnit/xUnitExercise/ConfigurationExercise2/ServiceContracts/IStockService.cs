using ConfigurationExercise2.ServiceContracts.DTO;

namespace ConfigurationExercise2.ServiceContracts
{
    public interface IStockService
    {
        BuyOrderResponse CreateBuyOrder(BuyOrderRequest? buyOrderRequest);
        SellOrderResponse CreateSellOrder(SellOrderRequest? SellOrderRequest);
        List<BuyOrderResponse> GetBuyOrders();
        List<SellOrderResponse> GetSellOrders();
    }
}
