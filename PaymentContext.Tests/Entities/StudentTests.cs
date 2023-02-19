using FluentValidation.Results;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Adicionar_Assinatura()
        {
            var subscription = new Subscription(DateTime.Now.AddMonths(1));

            var email = new Email("paulo_ramos@live.com");
            var address = new Address("Avenida Paraguaçu", "895", "", "Paraguaçu Paulista", "SP", "Brasil", "19700-000");
            var documento = new Documento("12345678901234", EDocumentType.CNPJ);
            var name = new Name("Paulo", "Ramos");


            var student = new Student(documento, name, email, address);

            StudentValidator validator = new StudentValidator();
            ValidationResult results = validator.Validate(student);

            Assert.AreEqual(true, results.IsValid);

        }

    }
}
