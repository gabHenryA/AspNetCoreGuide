using System.ComponentModel.DataAnnotations;
using ModelValidationExercise.Models;

namespace ModelValidationExercise.CustomValidators
{
    public class MinimumProductQuantityAttribute : ValidationAttribute
    {
        public int MinimumProducts { get; set; }
        public string DefaultErrorMessage { get; set; } = "This amount of product is not enough";

        public MinimumProductQuantityAttribute(int minimumProducts)
        {
            MinimumProducts = minimumProducts;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                List<Product> products = value as List<Product>;
                if(products.Count < MinimumProducts)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumProducts));
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            return null;
        }
    }
}
