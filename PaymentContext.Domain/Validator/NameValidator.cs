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
            RuleFor(name => name.FirstName).MinimumLength(3).WithMessage("O Campo nome não pode ser nulo ou menso que três caracteres.");
        }
    }
}
