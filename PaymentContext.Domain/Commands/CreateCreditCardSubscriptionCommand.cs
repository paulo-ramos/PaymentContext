using PaymentContext.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Commands
{
    public class CreateCreditCardSubscriptionCommand
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public string StudentDocumentNumber { get; set; } = string.Empty;
        public EDocumentType StudentDocumentType { get; set; }

        public string StudentStreet { get; set; } = string.Empty;
        public string StudentAddressNumber { get; set; } = string.Empty;
        public string StudentNeighborhood { get; set; } = string.Empty;
        public string StudentCity { get; set; } = string.Empty;
        public string StudentState { get; set; } = string.Empty;
        public string StudentCountry { get; set; } = string.Empty;
        public string StudentZipCode { get; set; } = string.Empty;

        public string CardHoldName { get; set; } = string.Empty;
        public string CardNumber { get; set; } = string.Empty;
        public string LastTransactionNumber { get; set; } = string.Empty;
        public string PaymentNumber { get; set; } = string.Empty;
        public DateTime PaidDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public decimal Total { get; set; }
        public decimal TotalPaid { get; set; }

        public string PayerDocumentNumber { get; set; } = string.Empty;
        public EDocumentType PayerDocumentType { get; set; }
        public string Payer { get; set; } = string.Empty;
        public String PayerEmail { get; set; } = string.Empty;

        public string PaymentStreet { get; set; } = string.Empty;
        public string PaymentAddressNumber { get; set; } = string.Empty;
        public string PaymentNeighborhood { get; set; } = string.Empty;
        public string PaymentCity { get; set; } = string.Empty;
        public string PaymentState { get; set; } = string.Empty;
        public string PaymentCountry { get; set; } = string.Empty;
        public string PaymentZipCode { get; set; } = string.Empty;
        public DateTime? PaymentExpiredDate { get; set; }
    }
}
