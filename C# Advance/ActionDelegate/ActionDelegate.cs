using System;
using System.Text.RegularExpressions;

public class Example1

{
    static void ToUpperCase(string input)
    {
        Console.WriteLine($"Chuoi viet hoa : {input.ToUpper()}");
    }
    public static void Run()
    {
        Action<string> action1 = ToUpperCase;

        Action<string> action2 = delegate (string input)
        {
            Console.WriteLine($"Chuoi viet thuong : {input.ToLower()}");
        };

        Action<string> action3 = input => Console.WriteLine($"Do dai chuoi : {input.Length}");

        Action<string> stringProcesser = action1 + action2 + action3;

        Console.WriteLine("Nhap chuoi can xu ly : ");
        string result = Console.ReadLine();

        Console.WriteLine("Ket qua : ");
        stringProcesser(result);

    }
}
