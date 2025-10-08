using ServiceContracts.DTO;

namespace ConfigurationExercise2.Models
{
    public class Orders
    {
        public List<BuyOrderResponse> BuyOrders { get; set; }
        public List<SellOrderResponse> SellOrders { get; set; }
    }
}
