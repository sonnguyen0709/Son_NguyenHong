public class Program
{
    public static void Main()
    {
        Console.WriteLine("Show Access:");
        new BaseClass().ShowMember();
        Console.WriteLine();

        new DerivedClass().ShowAccess();
        Console.WriteLine();

        new OtherClass().ShowAccess();
        Console.WriteLine();

        Console.WriteLine("Bank Account: ");
        BankAccount account = new BankAccount(2000);

        Console.WriteLine("Deposit: ");
        decimal deposit = Convert.ToDecimal(Console.ReadLine());
        account.Deposit(deposit);

        Console.WriteLine("WithDraw: ");
        decimal withdraw = Convert.ToDecimal(Console.ReadLine());
        account.WithDraw(withdraw);

        Console.WriteLine($"Current balance: {account.GetBalance()}");
    }
}
