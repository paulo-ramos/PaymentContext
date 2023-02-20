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


            //RuleFor(subscription => subscription)
            //    .Custom((subscription, context) =>
            //    {
            //        var exists = new List<string>();
            //        foreach (var sub in subscription)
            //        {
            //            if (sub.Active)
            //            {
            //                exists.Add($"O Aluno já possui uma assinatuta ativa, criada em [{sub.CreatedAt}], expira em [{sub.ExpiredDate}].");
            //            }

            //        }

            //        if (exists.Count > 1)
            //        {
            //            exists.ForEach(sub => context.AddFailure(sub));
            //        }
            //        return;
            //    }
            //    );



        }
    }
}
