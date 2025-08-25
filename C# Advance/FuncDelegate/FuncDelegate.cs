using System;
using System.Collections.Generic;
class Program
{
    static int ProcessNumber(int number, Func<int, int> operation)
    {
        return operation(number);
    }
    static int Calculate(int a, int b, Func<int, int, int> operation)
    {
        return operation(a, b);
    }
    static void Main()
    {
        Func<int> getRandomNumber = delegate ()
        {
            Random rnd = new Random();
            return rnd.Next(1, 101);
        };
        Console.WriteLine($"Con so ngau nhien: {getRandomNumber()}");

        Func<int, int> square = x => x * x;
        Console.WriteLine("Nhap so x: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Binh phuong cua x: {square(a)}");

        Func<int, int> db = x => x * 2;
        int doubled = ProcessNumber(a, db);
        Console.WriteLine($"Tich cua x va 2: {doubled}");

        Func<int, int, int> add = (x, y) => x + y;
        Console.WriteLine("Nhap so y: ");
        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Tong cua {a}, {b} la: {Calculate(a, b, add)}");
    }
}
