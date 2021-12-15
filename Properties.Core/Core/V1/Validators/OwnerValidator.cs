using FluentValidation;
using Properties.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Properties.Core.Core.V1.Validators
{
    public class OwnerValidator: AbstractValidator<Owner>
    {
        public OwnerValidator()
        {
            RuleFor(o => o.Name)
                .NotEmpty().WithMessage("Error: Owner name is Empty");

        }
    }
}
