using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace RepositoryCon
{
    public interface IStockRepositories
    {
        Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder);
        Task<SellOrder> CreateSellOrder(SellOrder sellOrder);
        Task<List<BuyOrder>> GetBuyOrders();
        Task<List<SellOrder>> GetSellOrders();
    }
}
