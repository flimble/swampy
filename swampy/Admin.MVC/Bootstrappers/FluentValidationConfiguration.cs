﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Attributes;
using FluentValidation.Mvc;

namespace Swampy.Admin.MVC.Bootstrappers
{
    public static class FluentValidationConfiguration
    {
        public static void Configure()
        {
            FluentValidationModelValidatorProvider.Configure();
        }
    }
}