using System;
using FluentValidation.Validators;

namespace Swampy.Business.Contract.Validators
{
    public class UrlValidator : PropertyValidator
    {
        public UrlValidator() : base("Property {PropertyName} must be a valid ")
        {
            
        }

       protected override bool IsValid(PropertyValidatorContext context)
       {
           var toValidate = context.PropertyValue as string;

           return Uri.IsWellFormedUriString(toValidate, UriKind.RelativeOrAbsolute);
       }
    }
}
