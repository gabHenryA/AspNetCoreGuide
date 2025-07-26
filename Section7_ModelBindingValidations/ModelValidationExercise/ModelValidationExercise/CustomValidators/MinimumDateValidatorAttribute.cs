using System.ComponentModel.DataAnnotations;

namespace ModelValidationExercise.CustomValidators
{
    public class MinimumDateValidatorAttribute : ValidationAttribute
    {
        public DateTime MinimumDate { get; set; }

        public string DefaultErrorMessage { get; set; } = "The minimum date is {0}";

        public MinimumDateValidatorAttribute(DateTime minimumDate)
        {
            MinimumDate = minimumDate;
        }  

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime date = Convert.ToDateTime(value);

                if(date < MinimumDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? DefaultErrorMessage, MinimumDate));
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
