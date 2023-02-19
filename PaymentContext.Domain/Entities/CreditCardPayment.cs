using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    public class CreditCardPayment : Payment 
    {
        public CreditCardPayment(
            string cardHoldName, 
            string cardNumber, 
            string lastTransactionNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            Documento documentNumber,
            string payer,
            Address address,
            Email email)
            : base(
                  paidDate,
                  expireDate,
                  total,
                  totalPaid,
                  documentNumber,
                  payer,
                  address,
                  email
            )
        {
            CardHoldName = cardHoldName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHoldName { get; private set; } = string.Empty;
        public string CardNumber { get; private set; } = string.Empty;
        public string LastTransactionNumber { get; private set; } = string.Empty;
    }

}
