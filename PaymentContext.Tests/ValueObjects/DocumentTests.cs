using FluentValidation.Results;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        //Red, Gren, Refactor
        [TestMethod]
        [DataTestMethod]
        [DataRow("68576638000100")]
        [DataRow("68576638000101")]
        [DataRow("68576638000102")]
        [DataRow("68576638000103")]
        [DataRow("68576638000104")]
        [DataRow("68576638000105")]
        public void ShouldReturnErrorWhenCNPJIsInvalid(string document)
        {
            var documento = new Documento(document, EDocumentType.CNPJ);
            DocumentoValidator validator = new DocumentoValidator();
            ValidationResult results = validator.Validate(documento);

            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("68576638000109")]
        [DataRow("93502503000146")]
        [DataRow("33699845000176")]
        [DataRow("51697289000180")]
        [DataRow("09071460000185")]
        [DataRow("13748768000190")]
        public void ShouldReturnSuccessWhenCNPJIsValid(string document)
        {
            var documento = new Documento(document, EDocumentType.CNPJ);
            DocumentoValidator validator = new DocumentoValidator();
            ValidationResult results = validator.Validate(documento);

            Assert.AreEqual(true, results.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("26186462000")]
        [DataRow("26186462001")]
        [DataRow("26186462002")]
        [DataRow("26186462003")]
        [DataRow("26186462004")]
        [DataRow("26186462005")]
        public void ShouldReturnErrorWhenCPFIsInvalid(string cpf)
        {
            var documento = new Documento(cpf, EDocumentType.CPF);
            DocumentoValidator validator = new DocumentoValidator();
            ValidationResult results = validator.Validate(documento);

            Assert.AreEqual(false, results.IsValid);
        }

        [TestMethod]
        [DataTestMethod]
        [DataRow("57033294000")]
        [DataRow("19610458009")]
        [DataRow("66269013038")]
        [DataRow("54631671092")]
        [DataRow("47979925068")]
        [DataRow("11285556038")]
        public void ShouldReturnSuccessWhenCPFIsValid(string cpf)
        {
            var documento = new Documento(cpf, EDocumentType.CPF);
            DocumentoValidator validator = new DocumentoValidator();
            ValidationResult results = validator.Validate(documento);

            Assert.IsTrue(results.IsValid);
        }
    }
}
