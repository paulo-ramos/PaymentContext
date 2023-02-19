using PaymentContext.Domain.ValueObjects;
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
        public Student(Document documentNumber, Name name, Email email)
        {
            DocumentNumber = documentNumber;
            Name = name;
            Email = email;
            _subscriptions= new List<Subscription>();
        }

        public Document DocumentNumber { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Address? Address { get; private set; }
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
