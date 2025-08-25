using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Thu nhap cua ban (trieu VND): ");
        double income = double.Parse(Console.ReadLine());

        double taxRate = (income <= 5) ? 0 :
            (income <= 15) ? 0.05 :
            (income <= 30) ? 0.10 : 0.20;
        double tax = income * 1_000_000 * taxRate;
        Console.WriteLine("Thue phai nop " + tax.ToString("N0") + " dong.");
    }
}