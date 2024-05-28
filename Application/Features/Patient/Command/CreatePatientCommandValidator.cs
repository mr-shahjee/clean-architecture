using Application.Features.Product.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Patient.Command
{
    public class CreatePatientCommandValidator: AbstractValidator<CreatePatientCommand>
    {

        public CreatePatientCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull()
             .WithMessage("{propertyName} is required").Length(2, 10).WithMessage("{propertyName} is between 2 and 10");

            RuleFor(x => x.Cnic).NotNull().NotEmpty().Length(2, 10);    

        }
    }
}
