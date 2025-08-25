using System;

class Example1
{
    public static void Run()
    {
        Action greet = delegate
        {
            Console.WriteLine("Chao mung ban.");
        };
        greet();

        Action<string> sayHello = delegate (string name)
        {
            Console.WriteLine($"Xin chao {name}");
        };

        Console.WriteLine("Nhap ten cua ban : ");
        string input = Console.ReadLine();
        sayHello(input);

        ExecuteGreeting(delegate (string name)
        {
            Console.WriteLine($"Chuc ban mot ngay tot lanh, {name}!");
        }, input);
    }
}

