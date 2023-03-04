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
    internal class SubscriptionValidator : AbstractValidator<Subscription>
    {
        public SubscriptionValidator()
        {
            RuleForEach(subscription => subscription.Payments).SetValidator(new PaymentValidator());

            RuleFor(subscription => subscription.ExpiredDate)
                .GreaterThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("Data de vencimento deve ser maior que a data atual.");

            RuleFor(subscription => subscription.CountPayments())
                .Must(countPayments => countPayments >= 1)
                .WithMessage($"Esta assinatura não possui pagamentos.");
        }
    }
}
