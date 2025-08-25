using System;
using MyApp.Extensions;
class Program
{
    static void Main()
    {
        Console.WriteLine("Nhap chuoi dau vao: ");
        string sentence = Convert.ToString(Console.ReadLine());
        Console.WriteLine($"So tu cua chuoi : {sentence.WordCount()}");

        Console.WriteLine("Nhap so tu nhien a: ");
        int a = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"{a} {(a.IsPrime() ? "la" : "khong la")} so nguyen to.");
    }
}