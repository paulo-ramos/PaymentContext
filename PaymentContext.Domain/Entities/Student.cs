using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class Student
    {
        private IList<Subscription> _subscriptions;
        public Student(string documentNumber, string firstName, string lastName, string email)
        {
            DocumentNumber = documentNumber;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            _subscriptions= new List<Subscription>();
        }

        public string DocumentNumber { get; private set; } = string.Empty;
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Address { get; private set; } = string.Empty;
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AssSubscription(Subscription subscription)
        {
            // se já tiver uma assinatura cancela

            //cancela todas as outras assinaturas e coloca esta como principal
            foreach(var sub in Subscriptions)
            {
                sub.Inactivate();
            }
            _subscriptions.Add(subscription);
        }

    }
}
