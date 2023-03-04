using FluentValidation;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Validator
{
    public class NameValidator : AbstractValidator<Name>
    {
        public NameValidator()
        {
            RuleFor(name => name.FirstName).MinimumLength(3).WithMessage("O Campo nome não pode ser nulo ou menor que três caracteres.");
            RuleFor(name => name.FirstName).MaximumLength(40).WithMessage("O Campo nome não pode conter mais de 40 caracteres.");
            RuleFor(name => name.LastName).MinimumLength(3).WithMessage("O Campo sobrenome não pode ser nulo ou menor que três caracteres.");
        }
    }
}
