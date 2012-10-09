using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Attributes;

namespace SAIG.PS.Swampy.Admin.MVC.Models.OperationModels
{
    [Validator(typeof(CreateEndpointValidator))]
    public class CreateEndpointOperationModel
    {

        public IDictionary<string, Type> EndpointTypes { get; set; }

        public Type EndpointType { get; set; }

        public string EnvironmentName { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }
    }

    public class CreateEndpointValidator : AbstractValidator<CreateEndpointOperationModel>
    {
        public CreateEndpointValidator()
        {
            RuleFor(x => x.Value)
                .NotEmpty()
                .WithMessage("test");



        }
    }
}