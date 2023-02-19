using FluentValidation;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Validator
{
    public class DocumentoValidator : AbstractValidator<Documento>
    {
        public DocumentoValidator()
        {
            RuleFor(documento => documento.Number).MinimumLength(11).WithMessage("Entre com 11 caracteres no mínimo para informar um CPF");
            RuleFor(documento => documento.Number).MaximumLength(14).WithMessage("Entre com 14 caracteres no méximo para informar um CNPJ");

            RuleFor(documento => documento.Number).Length(11).When(documento => documento.Type== EDocumentType.CPF).WithMessage("CPF deve conter 11 caracteres");
            RuleFor(documento => documento.Number).Length(14).When(documento => documento.Type == EDocumentType.CNPJ).WithMessage("CNPJ deve conter 14 caracteres");
        }
    }
}
