using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;

namespace Swampy.Admin.Web.Models.Operation
{
    [Validator(typeof(EnvironmentCloneValidator))]
    public class EnvironmentCloneModel
    {
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; }
        public string ParentEnvironmentName { get; set; }

        public List<ConfigurationItemInputModel> ConfigurationItems = new List<ConfigurationItemInputModel>(); 
    }


    public class EnvironmentCloneValidator : AbstractValidator<EnvironmentCloneModel>
    {
        public EnvironmentCloneValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Domain).NotEmpty();
            RuleFor(x => x.ParentEnvironmentName).NotEmpty();

            RuleFor(x => x.ConfigurationItems).SetCollectionValidator(new ConfigurationItemInputValidator());
        }
    }
}
