using System.ComponentModel.DataAnnotations;

namespace MoviesApp.Filters
{
    public class LessThan4Characters : ValidationAttribute
    {
        public LessThan4Characters()
        {
        }

        public string GetErrorMessage() =>
            $"The actor must have at least 4 characters of the first and last name";


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = (string)value;
            if (str.Length < 4)
            {
                return new ValidationResult(GetErrorMessage());
            }
                
            return ValidationResult.Success;
        }
    }
}