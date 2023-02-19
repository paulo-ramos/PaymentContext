namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode, 
            string boletoNumber, 
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
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; } = string.Empty;
        public string BoletoNumber { get; private set; } = string.Empty;
    }

}
