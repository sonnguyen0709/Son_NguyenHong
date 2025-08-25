using System;

class Example2
{
    static void ProcessString(string input, Action<string> handler)
    {
        handler(input); 
    }

    public static void Run()
    {
        Console.WriteLine("Nhap chuoi : ");
        string input = Console.ReadLine();

        Action<string> toUpper = delegate (string input)
        {
            Console.WriteLine($"Chuoi viet hoa : {input.ToUpper()}");
        };

        Action<string> toLower = delegate (string input)
        {
            Console.WriteLine($"Chuoi viet thuong : {input.ToLower()}");
        };

        Action<string> length = delegate (string input)
        {
            Console.WriteLine($"Do dai cua chuoi : {input.Length}");
        };

        Action<string> reverse = delegate (string input)
        {
            char[] arr = input.ToCharArray();
            Array.Reverse(arr);
            Console.WriteLine($"Chuoi dao nguoc : {new string(arr)}");
        };

        Action<string> processString = toUpper + toLower + length + reverse;
        ProcessString(input, processString);
    }
}