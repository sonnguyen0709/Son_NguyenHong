using System;

namespace ExampleDateTime
{
    class Program
    {
        static void Main()
        {
            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;

            int daysInMonth = DateTime.DaysInMonth(year, month);
            Console.WriteLine($"Lich thang {month}/{year}:");

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime d = new DateTime(year, month, day);
                Console.WriteLine($"{d:dd/MM/yyyy} - {d.DayOfWeek}");
            }
        }
    }
}
