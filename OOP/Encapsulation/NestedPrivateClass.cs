public class BankAccount
{
    private decimal balance;

    // Nested private class: only show for BankAccount
    private class TransactionLogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }
    private TransactionLogger logger = new TransactionLogger();
    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
        logger.Log($"Account created with balance: {balance}");
    }
    public void Deposit(decimal amount)
    {
        if (amount <= 0)
        {
            logger.Log("Invalid deposit ammount");
            return;
        }

        balance += amount;
        logger.Log($"Deposit: {amount}. New balance: {balance}");
    }
    public void WithDraw(decimal amount)
    {
        if (amount > balance)
        {
            logger.Log("Withdrawal failed: Insufficient funds");
            return;
        }

        balance -= amount;
        logger.Log($"WithDraw: {amount}. New balance: {balance}");
    }
    public decimal GetBalance()
    {
        return balance;
    }

}