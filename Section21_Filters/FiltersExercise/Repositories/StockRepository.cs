using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using RepositoryCon;

using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class StockRepository : IStockRepositories
    {
        private readonly StockMarketDbContext _db;

        public StockRepository(StockMarketDbContext stockMarketDbContext)
        {
            _db = stockMarketDbContext;
        }

        public async Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
        {
            _db.BuyOrders.Add(buyOrder);
            await _db.SaveChangesAsync();
            return buyOrder;
        }

        public async Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
        {
            _db.SellOrders.Add(sellOrder);
            await _db.SaveChangesAsync();
            return sellOrder;
        }

        public async Task<List<BuyOrder>> GetBuyOrders()
        {
            List<BuyOrder> buyOrders = await _db.BuyOrders.OrderByDescending(temp => temp.DateAndTimeOfOrder).ToListAsync();
            return buyOrders;
        }

        public async Task<List<SellOrder>> GetSellOrders()
        {
            List<SellOrder> sellOrders = await _db.SellOrders.OrderByDescending(temp => temp.DateAndTimeOfOrder).ToListAsync();
            return sellOrders;
        }
    }
}
