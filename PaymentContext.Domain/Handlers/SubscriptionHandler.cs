using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Repositories;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _studentRepository;

        public SubscriptionHandler(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            //fail fast validate 
            if (!command.Validate())
            {
                return new CommandResult(false, "Não foi possível realizar sua assinatura");
            }

            //gerar os VOs
            var documentNumberStudent = new Documento(command.StudentDocumentNumber, command.StudentDocumentType);
            var documentNumberPayer = new Documento(command.PayerDocumentNumber, command.PayerDocumentType);
            var emailStudent = new Email(command.StudentEmail);
            var emailPayer = new Email(command.PayerEmail);
            var nameStudent = new Name(command.FirstName, command.LastName);
            var addressStudent = new Address(
                command.StudentStreet, 
                command.StudentAddressNumber, 
                command.StudentNeighborhood, 
                command.StudentCity, 
                command.StudentState, 
                command.StudentCountry, 
                command.StudentZipCode);

            var addressPayer = new Address(
                command.PaymentStreet,
                command.PaymentAddressNumber,
                command.PaymentNeighborhood,
                command.PaymentCity,
                command.PaymentState,
                command.PaymentCountry,
                command.PaymentZipCode);

            //verificar se o documento está cadastrado
            if (_studentRepository.DocumentExists(documentNumberStudent))
            {
                return new CommandResult(false, "Documento já cadastrado.");
            }

            // verificar se o email está cadastrado
            if (_studentRepository.EmailExists(emailStudent))
            {
                return new CommandResult(false, "Email já cadastrado.");
            }


            //gerar as entidades
            var student = new Student(documentNumberStudent, nameStudent, emailStudent, addressStudent);
            var subscription = new Subscription(DateTime.Now.AddMonths(1));
            var payment = new BoletoPayment(
                command.BarCode,
                command.BoletoNumber, 
                command.PaidDate, 
                command.ExpireDate, 
                command.Total, 
                command.TotalPaid, 
                documentNumberPayer, 
                command.Payer, 
                addressPayer, 
                emailPayer);
            
            //relacionamentos
            subscription.AddPayment(payment);
            student.AddSubscription(subscription);


            //aplicar as validacoes

            //salvar as informacoes
            _studentRepository.CreateSubscription(student);

            //enviar emaild e boas vindas

            //retornar informações
            return new CommandResult(true, "Assinatura realizada com sucesso.");

        }
    }
}
