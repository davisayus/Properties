using FluentValidation;
using Properties.Entities.Dtos;
using Properties.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Core.Core.V1.Validators
{
    public class PropertyValidator: AbstractValidator<PropertyCreateDto>
    {
        public PropertyValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("Error: Property Name is Empty")
                .Length(5, 50).WithMessage("Error: Property Name max lenght(min=5, max=50) not valid");
                
            RuleFor(p => p.Description)
                .NotEmpty().WithMessage("Error: Property Description is Empty")
                .Length(5, 500).WithMessage("Error: Property Description max lenght(min=5, max=500) not valid");

            RuleFor(p => p.Area)
                .NotEmpty().WithMessage("Error: Property Area is Empty");

            RuleFor(p => p.City)
                .NotEmpty().WithMessage("Error: Property City is Empty")
                .Length(5, 20).WithMessage("Error: Property City max lenght(min=5, max=20) not valid");

            RuleFor(p => p.State)
                .NotEmpty().WithMessage("Error: Property State is Empty")
                .Length(2, 2).WithMessage("Error: Property State max lenght(min=2, max=2) not valid");

            RuleFor(p => p.ZipCode)
                .NotEmpty().WithMessage("Error: Property ZipCode is Empty")
                .Length(5, 5).WithMessage("Error: Property ZipCode max lenght(min=5, max=5) not valid");

        }
    }
}
