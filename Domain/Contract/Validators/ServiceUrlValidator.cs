using System;

namespace Swampy.Business.Contract.Validators
{
    public class ServiceUrlValidator : IValidate
    {
       public bool IsValid(string toValidate)
       {
           return Uri.IsWellFormedUriString(toValidate, UriKind.RelativeOrAbsolute);
       }
    }
}
