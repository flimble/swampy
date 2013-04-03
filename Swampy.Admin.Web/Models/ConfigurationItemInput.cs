﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Swampy.Business.Contract.Validators;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Models
{
    public class ConfigurationItemInput
    {
        public int? Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class ConfigurationItemInputValidator : AbstractValidator<ConfigurationItemInput>
    {
        public ConfigurationItemInputValidator()
        {
            RuleFor(x => x.Value).SetValidator(new UrlFluentValidator()).When(x => x.Type == "Url");
            RuleFor(x => x.Value).SetValidator(new DatabaseConnectionStringFluentValidator()).When(x => x.Type == "DatabaseConnectionString");
            RuleFor(x => x.Value).NotEmpty().When(x => x.Type == "Basic");
        }
    }
}