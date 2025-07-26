using System.ComponentModel.DataAnnotations;
using ConfigurationExercise2.Models.CustomValidators;

namespace ConfigurationExercise2.Models
{
    public class SellOrder
    {
        public Guid SellOrderID { get; set; }
        [Required]
        public string? StockSymbol { get; set; }
        [Required]
        public string? StockName { get; set; }
        [MinimumOrderDateValidator(2000)]
        public DateTime? DateAndTimeOfOrder { get; set; }
        [Range(1, 100000, ErrorMessage = "only quantities from 1 to 100000 are allowed")]
        public int? Quantity { get; set; }
        [Range(1, 10000, ErrorMessage = "only prices from 1 to 10000 are allowed")]
        public double? Price { get; set; }
    }
}
