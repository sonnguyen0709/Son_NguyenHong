using System;

namespace PaymentSystem
{
    // Custom EventArgs: contains payer name and amount
    public class PaymentEventArgs : EventArgs
    {
        public string PayerName { get; }
        public decimal Amount { get; }
        public PaymentEventArgs(string payerName, decimal amount)
        {
            PayerName = payerName;
            Amount = amount;
        }
    }

    // Publisher: handles payment processing
    public class PaymentProcessor
    {
        // Declaring an event using built-in EventHandler
        public event EventHandler<PaymentEventArgs> PaymentProcessed;
        public void ProcessPayment(string payerName, decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} from {payerName}...");
            OnPaymentProcessed(payerName, amount);
        }

        // Raise the event with both values
        protected virtual void OnPaymentProcessed(string payerName, decimal amount)
        {
            PaymentProcessed?.Invoke(this, new PaymentEventArgs(payerName, amount));
        }
    }

    // Subscriber: sends a receipt
    public class ReceiptService
    {
        public void SendReceipt(object sender, PaymentEventArgs e)
        {
            Console.WriteLine($"Receipt: {e.PayerName} paid {e.Amount} successfully.");
        }
    }

    // Subscriber: updates account balance
    public class AccountingSystem
    {
        public void UpdateBalance(object sender, PaymentEventArgs e)
        {
            Console.WriteLine($"Accounting: Updated balance after {e.PayerName}'s payment of {e.Amount}.");
        }
    }
}