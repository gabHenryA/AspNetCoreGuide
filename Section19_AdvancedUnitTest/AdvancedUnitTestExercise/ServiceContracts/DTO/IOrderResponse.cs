using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public interface IOrderResponse
    {
        string StockSymbol { get; set; }
        string StockName { get; set; }
        DateTime? DateAndTimeOfOrder { get; set; }
        int? Quantity { get; set; }
        double? Price { get; set; }
        double? TradeAmount { get; set; }
        OrderType OrderType { get; }




    }

    public enum OrderType
    {
        BuyOrder, SellOrder
    }
}
