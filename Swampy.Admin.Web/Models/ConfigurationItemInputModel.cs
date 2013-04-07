using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Swampy.Business.Contract.Validators;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Models
{
    public class ConfigurationItemInputModel
    {
        public int EnvironmentId { get; set; }
        public int? Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }

    public class ConfigurationItemInputValidator : AbstractValidator<ConfigurationItemInputModel>
    {
        public ConfigurationItemInputValidator()
        {
            RuleFor(x => x.Value).SetValidator(new UrlFluentValidator()).When(x => x.Type == "Url");
            RuleFor(x => x.Value).SetValidator(new DatabaseConnectionStringFluentValidator()).When(x => x.Type == "DatabaseConnectionString");
            RuleFor(x => x.Value).NotEmpty().When(x => x.Type == "Basic");

            RuleFor(x => x.Name).NotEmpty();
        }
    }
}