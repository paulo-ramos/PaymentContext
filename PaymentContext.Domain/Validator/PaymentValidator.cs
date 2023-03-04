using FluentValidation;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Validator
{
    internal class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(payment => payment.PaidDate)
                .NotEmpty()
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage(payment => $"A data do pagamento deve ser futura.[{payment.PaidDate}], [{DateTime.Now}]");

            RuleFor(payment => payment.Total)
                .GreaterThan(0)
                .WithMessage("O Valor total não pode ser zero.");

            RuleFor(payment => payment)
                .Must(payment => payment.TotalPaid >= payment.Total)
                .WithMessage("O Valor pago é menor que o valor total.");
        }
    }
}
