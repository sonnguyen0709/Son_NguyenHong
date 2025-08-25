using System;
using System.Collections.Generic;

namespace DelegatesDemo
{
    public delegate T Operation<T>(T a, T b);

    public delegate void LogAction(string message);
    class Program
    {
        public static T Execute<T>(T a, T b, Operation<T> op)
        {
            return op(a, b);
        }

        static int Add(int x, int y) => x + y;
        static int Multiply(int x, int y) => x * y;
        static string Join(string a, string b) => a + b;
        static void LogConsole(string message) => Console.WriteLine($"[Console] {message}");
        static void LogUpper(string message) => Console.WriteLine($"[Upper] {message}");
        static void Main()
        {
            Console.WriteLine("Delegate");
            Console.WriteLine("Nhap so a : ");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Nhap so b : ");
            int b = Convert.ToInt32(Console.ReadLine());

            int sum = Execute(a, b, Add);
            int product = Execute(a, b, Multiply);
            string name = Execute("Son", " Nguyen", Join);
            Console.WriteLine($"Tong: {sum}, Tich: {product}, Ten: {name}");

            Console.WriteLine("\n== Multicast Delegate ==");
            LogAction logger = LogConsole;
            logger += LogUpper;

            logger("This is a log message.");
        }
    }
}