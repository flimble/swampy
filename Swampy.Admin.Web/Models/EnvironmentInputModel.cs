using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using FluentValidation.Attributes;

namespace Swampy.Admin.Web.Models.Operation
{
    [Validator(typeof(EnvironmentInputValidator))]
    public class EnvironmentInputModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Description { get; set; } 

        public List<ConfigurationItemInputModel> ConfigurationItems = new List<ConfigurationItemInputModel>(); 
    }


    public class EnvironmentInputValidator : AbstractValidator<EnvironmentInputModel>
    {
        public EnvironmentInputValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Domain).NotEmpty();
        }
    }
}
