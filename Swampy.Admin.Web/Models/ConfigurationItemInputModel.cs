using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation;
using FluentValidation.Attributes;
using Swampy.Admin.Web.Infrastructure.HtmlExtensions;
using Swampy.Admin.Web.Models.Operation;
using Swampy.Business.Contract.Validators;
using Swampy.Business.DomainModel.Entities;

namespace Swampy.Admin.Web.Models
{
    [Validator(typeof(ConfigurationItemInputValidator))]
    public class ConfigurationItemInputModel
    {

        public int EnvironmentId { get; set; }
        public int? Id { get; set; }
        public ConfigurationItemType SelectedItemType { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public string ActualValue { get; set; }
    }

    public class ConfigurationItemInputValidator : AbstractValidator<ConfigurationItemInputModel>
    {
        public ConfigurationItemInputValidator()
        {
            RuleFor(x => x.Value).SetValidator(new UrlFluentValidator()).When(x => x.SelectedItemType == ConfigurationItemType.ServerUrl);
            RuleFor(x => x.Value).SetValidator(new DatabaseConnectionStringFluentValidator()).When(x => x.SelectedItemType == ConfigurationItemType.DatabaseConnectionString);
            RuleFor(x => x.Value).NotEmpty().When(x => x.SelectedItemType == ConfigurationItemType.Simple);

            RuleFor(x => x.Name).NotEmpty();
        }
    }
}