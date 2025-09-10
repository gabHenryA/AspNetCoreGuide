using System.ComponentModel.DataAnnotations;
using Entities.CustomValidators;

namespace Entities
{
    public class BuyOrder
    {
        public Guid BuyOrderID { get; set; }
        [Required(ErrorMessage = "Stock Symbol can't be blank")]
        public string? StockSymbol { get; set; }
        [Required(ErrorMessage = "Stock Name can't be blank")]
        public string? StockName { get; set; }
        [Required]
        [MinimumOrderDateValidator(2000)]
        public DateTime? DateAndTimeOfOrder { get; set; }
        [Range(1, 100000, ErrorMessage = "only quantities from 1 to 100000 are allowed")]
        public int? Quantity { get; set; }
        [Range(1, 100000, ErrorMessage = "only prices from 1 to 10000 are allowed")]
        public double? Price { get; set; }
    }
}
