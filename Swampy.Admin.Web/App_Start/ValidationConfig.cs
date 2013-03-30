using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Attributes;
using FluentValidation.Mvc;

namespace Swampy.Admin.Web.Bootstrappers
{
    public static class ValidationConfig
    {
        public static void Configure()
        {
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}
