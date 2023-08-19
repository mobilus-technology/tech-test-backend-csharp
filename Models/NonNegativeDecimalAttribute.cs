using System.ComponentModel.DataAnnotations;

namespace WebApiProduct.Models;

public class NonNegativeDecimalAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value is decimal price && price < 0) return new ValidationResult("O preço não pode ser negativo.");

        return ValidationResult.Success;
    }
}
