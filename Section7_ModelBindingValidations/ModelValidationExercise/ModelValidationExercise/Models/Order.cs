using System.ComponentModel.DataAnnotations;
using ModelValidationExercise.CustomValidators;

namespace ModelValidationExercise.Models
{
    public class Order : IValidatableObject
    {
        public int? OrderNo { get; set; }

        [Required]
        public DateTime? OrderDate { get; set; }

        [Required]
        [MinimumProductQuantity(1, ErrorMessage = "The minimum quantity of products is {0}")]
        public List<Product>? Products { get; set; }

        [Required]
        public double? InvoicePrice { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            if(InvoicePrice != Products.Sum((p) => p.Price * p.Quantity))
            {
                yield return new ValidationResult("InvoicePrice doesn't match with the total cost of the specified products in the order.", new string[] { nameof(InvoicePrice)});
            }

            if(OrderDate < new DateTime(2000, 01, 01))
            {
                yield return new ValidationResult("Order date should be greater than or equal to 2000-01-01.", new string[] { nameof(OrderDate) });
            }
        }



        //public double? InvoicePrice => Products.Sum((p) => p.Price);

        //public double? InvoicePrice()
        //{
        //    return Products.Sum((p) => p.Price);
        //}


        //public double? InvoicePrice()
        //{
        //    double? price = 0;

        //    foreach (var product in Products)
        //    {
        //        price += product.Price;
        //    }

        //    return price;
        //}
    }
}
