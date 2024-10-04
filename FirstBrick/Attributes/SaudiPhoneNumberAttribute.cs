using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FirstBrick.CustomAttributes;

public class SaudiPhoneNumberAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        // If the value is null or empty, we consider it valid (because it's optional in some cases)
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            return true;

        var phoneNumber = NormalizePhoneNumber(value.ToString());
        return Regex.IsMatch(phoneNumber, @"^\+9665\d{8}$");
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        // If the value is null or empty, we consider it valid (because it's optional in some cases)
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            return ValidationResult.Success;

        if (!IsValid(value))
        {
            return new ValidationResult("Please enter a valid Saudi phone number.");
        }

        var phoneNumber = NormalizePhoneNumber(value.ToString());
        var property = validationContext.ObjectType.GetProperty(validationContext.MemberName);
        if (property != null)
        {
            property.SetValue(validationContext.ObjectInstance, phoneNumber, null);
        }

        return ValidationResult.Success;
    }

    private string NormalizePhoneNumber(string phoneNumber)
    {
        phoneNumber = phoneNumber.Trim();

        if (phoneNumber.StartsWith("00"))
        {
            phoneNumber = "+" + phoneNumber.Substring(2);
        }

        if (phoneNumber.StartsWith("0"))
        {
            phoneNumber = "+966" + phoneNumber.Substring(1);
        }

        if (phoneNumber.StartsWith("966"))
        {
            phoneNumber = "+" + phoneNumber;
        }

        if (!phoneNumber.StartsWith("+966"))
        {
            phoneNumber = "+966" + phoneNumber;
        }

        return phoneNumber;
    }

}
