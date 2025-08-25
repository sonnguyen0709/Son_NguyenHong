using System;

namespace ExampleDateTime
{
    class Program
    {
        static void Main()
        {
            Console.Write("Nhap ngay sinh cua ban (vi du: 25/12/2000): ");
            string input = Console.ReadLine();

            // Dung TryParse de chuyen chuoi thanh DateTime
            if (DateTime.TryParse(input, out var birthDay))
            {
                DateTime nowDay = DateTime.Today;
                int age = nowDay.Year - birthDay.Year;

                // Neu ngay sinh chua toi trong nam nay thi tru di 1
                if (birthDay > nowDay.AddYears(-age))
                {
                    age--;
                }

                Console.WriteLine($"Ban {age} age.");
                if (age >= 18)
                    Console.WriteLine("Ban da du 18 age.");
                else
                    Console.WriteLine("Ban chua du 18 age.");
            }
            else
            {
                Console.WriteLine("Ngay sinh khong hop le!");
            }
        }
    }
}
