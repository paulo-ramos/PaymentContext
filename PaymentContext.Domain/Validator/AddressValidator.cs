using FluentValidation;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PaymentContext.Domain.Validator
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Street).NotEmpty().WithMessage("O campo nome da Rua não pode ser vazio");
            RuleFor(address => address.Number).NotEmpty().WithMessage("O campo número não pode ficar vazio");
            RuleFor(address => address.City).NotEmpty().WithMessage("O Nome da cidade não pode ficar vazio");
            RuleFor(address => address.State).NotEmpty().WithMessage("O Noem do estado não pode ficar vazio");
            RuleFor(address => address.Country).NotEmpty().WithMessage("O Noem do pais não pode ficar vazio");
            RuleFor(address => address.ZipCode).NotEmpty().WithMessage("O Código Postal não pode ficar vazio");
        }

    }
}
