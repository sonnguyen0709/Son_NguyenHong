using PaymentSystem;
using System;
using PaymentSystem;

// Define delegate for the event
public delegate void AlarmEventHandler(object sender, EventArgs e);

// Publisher (raises the event)
public class AlarmClock
{
    // Declare an event based on the delegate
    public event AlarmEventHandler AlarmRang;

    // Method to simulate the alarm ringing
    public void Ring()
    {
        Console.WriteLine("Alarm is ringing...");
        // Trigger the event
        OnAlarmRang();
    }

    // Protected method to raise the event
    protected virtual void OnAlarmRang()
    {
        AlarmRang?.Invoke(this, EventArgs.Empty);
    }
}

// Subscriber (listens to the event)
public class Person
{
    private string name;

    public Person(string name)
    {
        this.name = name;
    }

    // Event handler method for when the alarm rings
    public void WakeUp(object sender, EventArgs e)
    {
        Console.WriteLine($"{name} woke up because the alarm rang.");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Alarm clock");
        AlarmClock clock = new AlarmClock();
        Person john = new Person("John");
        Person alice = new Person("Alice");
        // Subscribe event handler methods to the event
        clock.AlarmRang += john.WakeUp;
        clock.AlarmRang += alice.WakeUp;
        // Call Ring to trigger the event
        clock.Ring();

        Console.WriteLine("Payment");
        // Create instances
        PaymentProcessor processor = new PaymentProcessor();
        ReceiptService receiptService = new ReceiptService();
        AccountingSystem accounting = new AccountingSystem();
        // Subscribe to event
        processor.PaymentProcessed += receiptService.SendReceipt;
        processor.PaymentProcessed += accounting.UpdateBalance;
        // Simulate payment
        processor.ProcessPayment("Son", 150.00m);
        processor.ProcessPayment("Nguyen", 75.50m);
    }
    }