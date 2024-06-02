using Application.Behaviors;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException() : base("One or more validations occured.")
        {
            Errors = new List<string>();
        }
        public ValidationErrorException(List<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
        public List<string> Errors { get; set; }

    }
}
