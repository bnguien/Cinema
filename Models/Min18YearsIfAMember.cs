using System;
using System.ComponentModel.DataAnnotations;

namespace MyMVCApp.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (validationContext.ObjectInstance is not Customer customer)
                return new ValidationResult("Invalid object type.");

            if (!customer.Birthdate.HasValue)
                return new ValidationResult("Birthdate is required.");

            var birthdate = customer.Birthdate.Value;
            if (birthdate > DateTime.Today)
                return new ValidationResult("Birthdate cannot be in the future.");
            var age = DateTime.Today.Year - birthdate.Year;
            if (birthdate > DateTime.Today.AddYears(-age)) 
                age--;

            if (age < 16)
                return new ValidationResult("Customer must be at least 16 years old.");

            if (customer.MembershipTypeId != MembershipType.Unknown &&
                customer.MembershipTypeId != MembershipType.PayAsYouGo &&
                age < 18)
            {
                return new ValidationResult("Customer should be at least 18 years old to go on a membership.");
            }

            return ValidationResult.Success!;
        }
    }
}
