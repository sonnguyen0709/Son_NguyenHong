using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Nhap chuoi: ");
        string input = Console.ReadLine();

        StringBuilder sb = new StringBuilder(input);

        for (int i = sb.Length - 1; i >= 0; i--)
        {
            if (!char.IsLetterOrDigit(sb[i]) && sb[i] != ' ')//Xac dinh ky tu co phai so hay chu
            {
                sb.Remove(i, 1);
            }
        }

        Console.WriteLine("Chuoi sau khi xoa ky tu dac biet:");
        Console.WriteLine(sb.ToString());

        StringBuilder sb1 = new StringBuilder(input);
        char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        foreach (char v in vowels)
        {
            sb1.Replace(v.ToString(), "*");//Thay the chu thuong
            sb1.Replace(v.ToString().ToUpper(), "*");//Thay the chu hoa
        }

        Console.WriteLine("Chuoi sau khi thay nguyen am bang '*':");
        Console.WriteLine(sb1.ToString());
    }
}
