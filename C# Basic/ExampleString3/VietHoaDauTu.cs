using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhap mot cau: ");
        string input = Console.ReadLine();

        string[] words = input.Split(' ');//Chia cac tu cach nhau ' '
        for (int i = 0; i < words.Length; i++)
        {
            string word = words[i];
            if (word.Length > 0)
            {
                words[i] = char.ToUpper(word[0]) + word.Substring(1).ToLower();//Chuyen moi tu thanh viet hoa dau 
            }
        }

        string result = string.Join(" ", words);
        Console.WriteLine("Chuoi da viet hoa moi tu: " + result);
    }
}
