using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace FirstBrick.CustomAttributes;

public class ValidDateAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // Try parsing the date considering culture invariant and allowing flexibility in day and month digits
        if (DateTime.TryParseExact(value.ToString(), ["yyyy-M-d", "yyyy-MM-dd", "yyyy-M-dd", "yyyy-MM-d"],
            CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
        {
            if (date > DateTime.UtcNow)
            {
                return new ValidationResult("Birthdate cannot be in the future.");
            }

            // Calculate age
            var age = DateTime.UtcNow.Year - date.Year;
            if (date > DateTime.UtcNow.AddYears(-age)) age--;

            // Check if age is at least 18
            if (age < 18)
            {
                return new ValidationResult("You must be at least 18 years old.");
            }

            return ValidationResult.Success;
        }

        return new ValidationResult("Please enter a valid date in the format yyyy-MM-dd.");
    }
}
