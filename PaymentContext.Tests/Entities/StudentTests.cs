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

            var subscription1 = new Subscription(DateTime.Now.AddMonths(1));
            var subscription2 = new Subscription(DateTime.Now.AddMonths(2));
            var subscription3 = new Subscription(DateTime.Now.AddMonths(3));

            var email = new Email("paulo_ramos@live.com");
            var address = new Address("Avenida Paraguaçu", "895", "", "Paraguaçu Paulista", "SP", "Brasil", "19700-000");
            var documento = new Documento("68576638000109", EDocumentType.CNPJ);
            var name = new Name("Paulo", "Ramos");

            decimal valorTotal = 100;
            decimal valorTotalPaid = 100;

            var payment = new PayPalPayment("12345678901234567890", DateTime.Now, DateTime.Now, valorTotal, valorTotalPaid, documento, "pai do davi", address, email);

            subscription1.AddPayment(payment);
            subscription2.AddPayment(payment);
            subscription3.AddPayment(payment);


            var student = new Student(documento, name, email, address);

            subscription1.Inactivate(); //inativar pois só pode aceitar uma matrícula ativa.
            subscription3.Inactivate(); //inativar pois só pode aceitar uma matrícula ativa.
            student.AddSubscription(subscription1);
            student.AddSubscription(subscription2);
            student.AddSubscription(subscription3);


            StudentValidator validator = new StudentValidator();
            ValidationResult results = validator.Validate(student);

            Assert.AreEqual(true, results.IsValid);

        }

    }
}
