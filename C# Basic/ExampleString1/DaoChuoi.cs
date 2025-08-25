using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap chuoi can dao nguoc: ");
        string input = Console.ReadLine();

        if (string.IsNullOrEmpty(input))//Dam bao chuoi khong rong
        {
            Console.WriteLine("Chuoi rong.");
            return;
        }

        string output = "";
        for (int i = input.Length - 1; i >= 0; i--)//Duyet tu duoi cua chuoi
        {
            output += input[i];
        }

        Console.WriteLine($"Chuoi dao nguoc: {output}");

        if (input == output)
        {
            Console.WriteLine("Chuoi la chuoi doi xung.");
        }
        else
        {
            Console.WriteLine("Chuoi khong phai chuoi doi xung.");
        }
    }
}
