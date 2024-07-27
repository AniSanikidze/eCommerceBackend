using eCommerce.Payment.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Payment.Domain.Transactions
{
    public sealed class Transaction : Entity
    {
        public Guid OrderId { get; private set; }
        public DateTime TransactionDate { get; private set; }
        public decimal Amount { get; private set; }
        public string PaymentMethod { get; private set; }

        public Transaction(Guid id,Guid orderId, DateTime transactionDate, decimal amount, string paymentMethod)
            : base(id)
        {
            OrderId = orderId;
            TransactionDate = transactionDate;
            Amount = amount;
            PaymentMethod = paymentMethod;
        }
        //ToDo: Confirm and reject methods
    }
}
