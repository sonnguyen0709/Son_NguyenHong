using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap chuoi: ");
        string s = Console.ReadLine();

        Console.Write("Nhap ky tu muon dem: ");
        char chars = Console.ReadKey().KeyChar;
        Console.WriteLine();

        int count = 0;
        foreach (char c in s)
        {
            if (c == chars)
                count++;
        }

        Console.WriteLine($"Ky tu '{chars}' xuat hien {count} lan.");
    }
}
