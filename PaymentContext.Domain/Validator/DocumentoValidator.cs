using FluentValidation;
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
    public class DocumentoValidator : AbstractValidator<Documento>
    {
        public DocumentoValidator()
        {
            RuleFor(documento => documento)
                .Custom((documento, context) =>
                {
                    if((documento.Type == EDocumentType.CPF  && ValidaCpf.IsValid(documento.Number)) ||
                       (documento.Type == EDocumentType.CNPJ && ValidaCnpj.IsValid(documento.Number))
                       )
                    {
                        return;
                    }
                    context.AddFailure($"Documento [{documento.Number}] não corresponde ao tipo [{documento.Type}].");
                }
                );


        }
    }
}
