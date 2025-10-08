using System.ComponentModel.DataAnnotations;

namespace Entities.CustomValidators
{
    public class MinimumOrderDateValidatorAttribute : ValidationAttribute
    {
        public int MinimumYearDate { get; set; }

        public string DefaultErrorMessage { get; set; } = "DateTime can't be less than {0}";

        public MinimumOrderDateValidatorAttribute() { }

        public MinimumOrderDateValidatorAttribute(int minimumYearDate)
        {
            MinimumYearDate = minimumYearDate;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime date = (DateTime)value;
                if(date.Year < MinimumYearDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumYearDate));
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
