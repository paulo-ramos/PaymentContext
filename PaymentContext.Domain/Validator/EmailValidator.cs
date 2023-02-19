using FluentValidation;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Validator
{
    public class EmailValidator : AbstractValidator<Email>
    {
        public EmailValidator()
        {
            RuleFor(email => email.Address).NotEmpty().WithMessage("O campo Email é obrigatório");
            RuleFor(email => email.Address).EmailAddress().WithMessage("Informe um Email válido.");
        }
    }
}
