using System;
namespace MyApp.Extensions
{
    public static class ExtensionsMethod
    {
        public static int WordCount(this string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            return str.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static bool IsPrime(this int number)
        {
            if (number < 1) return false;
            if (number == 2) return true;
            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    }
}
