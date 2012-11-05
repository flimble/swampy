using FluentValidation;
using FluentValidation.Attributes;

namespace Swampy.Admin.Web.Models.OperationModels.Endpoint
{
    public class CreateSimpleEndpointValidator : CreateEndpointBaseValidator<CreateSimpleEndpoint>
    {
        public CreateSimpleEndpointValidator()
        {

            RuleFor(n => n.Value)
                .NotEmpty();


        }

    }

    [Validator(typeof(CreateSimpleEndpointValidator))]
    public class CreateSimpleEndpoint : CreateEndpointBase
    {
        public string Value { get; set; }
    }
}