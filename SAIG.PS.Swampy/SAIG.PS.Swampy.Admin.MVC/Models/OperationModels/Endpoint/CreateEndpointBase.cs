using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;

namespace SAIG.PS.Swampy.Admin.MVC.Models.OperationModels
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