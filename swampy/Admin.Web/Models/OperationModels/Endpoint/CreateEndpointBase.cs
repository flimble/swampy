using FluentValidation;

namespace Swampy.Admin.Web.Models.OperationModels.Endpoint
{
    public class CreateEndpointBase
    {
        protected string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
      
    }


    public class CreateEndpointBaseValidator<TEndpoint> : AbstractValidator<TEndpoint> where TEndpoint : CreateEndpointBase
    {
        public CreateEndpointBaseValidator()
        {
            RuleFor(n => n.Name)
                .NotEmpty();          
        }

    }
}