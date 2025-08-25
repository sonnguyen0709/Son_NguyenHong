using System;

namespace ExampleDateTime
{
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap nam muon kiem tra (vi du: 2025): ");
            string input = Console.ReadLine();
            int count = 0;

            if(int.TryParse(input, out int year) && year > 0)//Kiem tra nam nhap co hop le
            {
                for (int month = 1; month <= 12; month++)
                {
                    int dayCount = DateTime.DaysInMonth(year, month);
                    for (int day = 1; day <= dayCount; day++)
                    {
                        DateTime d = new DateTime(year, month, day);
                        if (d.DayOfWeek == DayOfWeek.Saturday || d.DayOfWeek == DayOfWeek.Sunday)//Kiem tra co phai cuoi tuan
                        {
                            count++;
                        }
                    }
                }

                Console.WriteLine($"Nam {year} co {count} ngay cuoi tuan.");
            }
            else
            {
                Console.WriteLine("Nam nhap vao khong hop le!");
            }

        }
    }
}