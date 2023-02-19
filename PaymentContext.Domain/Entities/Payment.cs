﻿using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public abstract class Payment
    {
        protected Payment(DateTime paidDate, DateTime expireDate, decimal total, decimal totalPaid, Document documentNumber, string payer, Address address, Email email)
        {
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,10).ToUpper();
            PaidDate = paidDate;
            ExpireDate = expireDate;
            Total = total;
            TotalPaid = totalPaid;
            DocumentNumber = documentNumber;
            Payer = payer;
            Address = address;
            Email = email;
        }

        public string Number { get; private set; } = string.Empty;
        public DateTime PaidDate { get; private set; }
        public DateTime ExpireDate { get; private set; }
        public decimal Total { get; private set; }
        public decimal TotalPaid { get; private set; }
        public Document DocumentNumber { get; private set; }
        public string Payer { get; private set; } = string.Empty;
        public Address Address { get; private set; }
        public Email Email { get; private set; }

    }

}
