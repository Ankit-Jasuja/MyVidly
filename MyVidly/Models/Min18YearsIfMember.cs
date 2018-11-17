using System;
using System.ComponentModel.DataAnnotations;

namespace MyVidly.Models
{
    public class Min18YearsIfMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
           var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MembershipTypeId == (int)MemberShipTypeValue.None || customer.MembershipTypeId == (int)MemberShipTypeValue.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate == null)
            {
                return new ValidationResult("Please enter birthdate");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            if (age >= 18)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("customer must be 18 years of age");
        }
    }
}