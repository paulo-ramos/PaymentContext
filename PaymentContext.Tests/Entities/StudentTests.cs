using FluentValidation.Results;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Validator;
using PaymentContext.Domain.ValueObjects;
using System.Net;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        private readonly Name _name;
        private readonly Documento _documento;
        private readonly Address _address;
        private readonly Email _email;
        private readonly Student _student;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Paulo", "Ramos");
            _documento = new Documento("68576638000109", EDocumentType.CNPJ);
            _email = new Email("paulo_ramos@live.com");
            _address = new Address("Avenida Paraguaçu", "895", "", "Paraguaçu Paulista", "SP", "Brasil", "19700-000");            
            
            _subscription = new Subscription(null);
            _student = new Student(_documento, _name, _email, _address);            
        }

        [TestMethod]
        public void ShouldReturn_Error_When_HadActive_Subscription()
        {
            var payment = new PayPalPayment("12345678901234567890", DateTime.Now, DateTime.Now, 10, 10, _documento, "pai do davi", _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            StudentValidator validator = new StudentValidator();
            ValidationResult results = validator.Validate(_student);

            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        public void ShouldReturn_Error_When_Subscription_HasNo_Payments()
        {
            _student.AddSubscription(_subscription);

            StudentValidator validator = new StudentValidator();
            ValidationResult results = validator.Validate(_student);

            Assert.IsFalse(results.IsValid);
        }

        [TestMethod]
        public void ShouldReturn_Success_When_Add_Subscription()
        {
            var payment = new PayPalPayment("12345678901234567890", DateTime.Now, DateTime.Now, 10, 10, _documento, "pai do davi", _address, _email);

            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            StudentValidator validator = new StudentValidator();
            ValidationResult results = validator.Validate(_student);

            Assert.IsTrue(results.IsValid);
        }

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
