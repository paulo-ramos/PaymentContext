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
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(student => student.DocumentNumber).SetValidator(new DocumentoValidator());
            RuleFor(student => student.Name).SetValidator(new NameValidator()); 
            RuleFor(student => student.Email).SetValidator(new EmailValidator());
            RuleFor(student => student.Address).SetValidator(new AddressValidator());
            RuleFor(student => student.CountSubscriptions())
                .Must(countSubscriptions => countSubscriptions <= 1)
                .WithMessage($"O Aluno não pode possuir mais de uma matrícula ativa.");
            RuleForEach(student => student.Subscriptions).SetValidator(new SubscriptionValidator());
        }
    }
}
