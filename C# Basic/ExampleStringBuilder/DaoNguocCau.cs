using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Nhap cau: ");
        string input = Console.ReadLine().Trim();

        StringBuilder word = new StringBuilder();
        StringBuilder result = new StringBuilder();

        for (int i = input.Length - 1; i >= 0; i--)
        {
            if (input[i] != ' ')
                word.Insert(0, input[i]);//Gan tung ky tu trong tu vao word
            else if (word.Length > 0)
            {
                result.Append(word).Append(" ");//Gan tu trong word vao cau dao nguoc
                word.Clear();//Clear 
            }
        }

        if (word.Length > 0)
            result.Append(word); // tu cuoi cung khong co dau " " dang sau nen them truc tiep vao ket qua

        Console.WriteLine("Cau sau khi dao nguoc cac tu:");
        Console.WriteLine(result.ToString());
    }
}
