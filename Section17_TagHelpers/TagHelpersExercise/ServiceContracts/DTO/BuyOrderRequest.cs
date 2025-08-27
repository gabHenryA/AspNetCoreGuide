﻿using System.ComponentModel.DataAnnotations;
using Entities;

namespace ServiceContracts.DTO
{
    public class BuyOrderRequest
    {
        [Required]
        public string? StockSymbol { get; set; }
        [Required]
        public string? StockName { get; set; }
        public DateTime? DateAndTimeOfOrder { get; set; }
        [Range(1, 100000, ErrorMessage = "only quantities from 1 to 100000 are allowed")]
        public int? Quantity { get; set; }
        [Range(1, 100000, ErrorMessage = "only prices from 1 to 10000 are allowed")]
        public double? Price { get; set; }

        public BuyOrder ToBuyOrder()
        {
            return new BuyOrder
            {
                StockSymbol = StockSymbol,
                StockName = StockName,
                DateAndTimeOfOrder = DateAndTimeOfOrder,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
}
