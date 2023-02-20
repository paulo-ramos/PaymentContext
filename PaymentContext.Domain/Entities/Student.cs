using FluentValidation;
using FluentValidation.Results;
using PaymentContext.Domain.Validator;
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
        public Student(Documento documentNumber, Name name, Email email, Address address)
        {
            DocumentNumber = documentNumber;
            Name = name;
            Email = email;
            Address = address;
            _subscriptions= new List<Subscription>();
        }

        public Documento DocumentNumber { get; private set; }
        public Name Name { get; private set; }
        public Email Email { get; private set; }
        public Address Address { get; private set; }
        public IReadOnlyCollection<Subscription> Subscriptions { get { return _subscriptions.ToArray(); } }

        public void AddSubscription(Subscription subscription)
        {
            _subscriptions.Add(subscription);
            
        }

        public int CountSubscriptions()
        {
            return _subscriptions.Count(s => s.Active == true);
        }

    }
}
