..; using System;

namespace DateTimeExample
{
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap ngay bat dau (dd/MM/yyyy): ");
            string input1 = Console.ReadLine();

            Console.Write("Nhap ngay ket thuc (dd/MM/yyyy): ");
            string input2 = Console.ReadLine();

            bool isValid1 = DateTime.TryParse(input1, out DateTime start);//kiem tra xem ngay nhap co dung khong
            bool isValid2 = DateTime.TryParse(input2, out DateTime end);

            if (isValid1 && isValid2)
            {
                TimeSpan duration = end - start;
                Console.WriteLine($"So ngay giua 2 ngay la: {duration.TotalDays} ngay.");
            }
            else
            {
                Console.WriteLine("Mot hoac ca hai ngay nhap vao khong hop le.");
            }
        }
    }
}