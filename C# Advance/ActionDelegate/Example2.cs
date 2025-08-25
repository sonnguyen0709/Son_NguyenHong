using System;

public class Example2
{
    static void SayHello()
    {
        Console.WriteLine("Hello!");
    }

    public static void Run()
    {
        Action greet = SayHello;
        greet();

        Action<int, int> tinh = (a, b) =>
        {
            Console.WriteLine($"Tong: {a + b}");
            Console.WriteLine($"Hieu: {a - b}");
        };

        Console.WriteLine("Nhap so a : ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Nhap so b : ");
        int b = Convert.ToInt32(Console.ReadLine());
        tinh(a, b);

    }
}
