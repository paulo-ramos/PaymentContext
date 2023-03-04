using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payments;
        public Subscription(DateTime? expiredDate)
        {
            CreatedAt = DateTime.Now;
            UpdatedAt = CreatedAt;
            ExpiredDate = expiredDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
        public DateTime? ExpiredDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment>? Payments { get{ return _payments.ToArray(); } }

        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }

        public void Activate()
        {
            Active = true;
            UpdatedAt= DateTime.Now;
        }

        public void Inactivate()
        {
            Active = false;
            UpdatedAt = DateTime.Now;
        }

        public int CountPayments()
        {
            return _payments.Count(p => p.ExpireDate >= DateTime.Now.Date);
        }
    }
}
