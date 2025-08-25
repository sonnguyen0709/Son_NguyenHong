using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Nhap chuoi so: ");
        string numbers = Console.ReadLine();

        Console.Write("Nhap do dai chuoi con: ");
        if (!int.TryParse(Console.ReadLine(), out int sliceLength) || sliceLength <= 0)//Kiem tra neu do dai chuoi con hop le
        {
            Console.WriteLine("Do dai khong hop le.");
            return;
        }

        if (sliceLength > numbers.Length)//Chuoi con phai co do dai nho hon dau vao
        {
            Console.WriteLine("Do dai chuoi con lon hon do dai chuoi.");
            return;
        }

        if (!numbers.All(char.IsDigit))//Dam bao chuoi chi toan so
        {
            Console.WriteLine("Chuoi chi duoc chua cac chu so.");
            return;
        }

        var slices = new List<string>();//Tao list ket qua

        for (int i = 0; i <= numbers.Length - sliceLength; i++)
        {
            string slice = numbers.Substring(i, sliceLength);
            slices.Add(slice);
        }

        Console.WriteLine("Cac chuoi con:");
        foreach (var s in slices)
        {
            Console.WriteLine(s);
        }

        List<int> products = new List<int>();//Tim tich cua moi chuoi
        foreach (var s in slices)
        {
            int product = 1;
            foreach (char c in s)
            {
                product *= (c - '0');
            }
            products.Add(product);
        }

        int maxProduct = products.Max();
        Console.WriteLine($"Tich lon nhat trong chuoi la: {maxProduct}");//In ra tich lon nhat
    }
}
