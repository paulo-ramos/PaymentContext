namespace PaymentContext.Domain.Entities
{
    public class PayPalPayment : Payment
    {
        public PayPalPayment(
            string transactionCode,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string documentNumber,
            string payer,
            string address,
            string email)
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
            TransactionCode = transactionCode;
        }

        public string TransactionCode { get; private set; } = string.Empty;
    }

}
