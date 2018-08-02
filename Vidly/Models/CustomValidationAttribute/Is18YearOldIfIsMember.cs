using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models.CustomValidationAttribute
{
    public class Is18YearOldIfIsMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer =(Customer) validationContext.ObjectInstance;
            if(customer.MembershipTypeId == 0)
                return ValidationResult.Success;
            if(customer.BirthDay == null)
                return new ValidationResult("This feld can not be null.");
            var age = DateTime.Now.Year - customer.BirthDay.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer must be lest 18 years old if a member.");
        }
    }
}