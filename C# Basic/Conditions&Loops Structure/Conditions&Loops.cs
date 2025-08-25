using System;

namespace ConditionsLoops
{
    class Program
    {
        static void Main()
        {
            //Cau lenh dieu kien jf, else
            int a, b, c;
            Console.WriteLine("Enter a :");
            a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter b :");
            b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter c :");
            c = Convert.ToInt32(Console.ReadLine());

            if (a > b && a > c)
            {
                Console.WriteLine($"So lon nhat la : {a}");
            }
            else if (b > a && b > c)
            {
                Console.WriteLine($"So lon nhat la : {b}");
            }
            else if (c > a && c > b)
            {
                Console.WriteLine($"So lon nhat la : {c}");
            }
            else
            {
                Console.WriteLine($"Ca 3 so a ,b ,c bang nhau");
            }

            //Cau lenh dieu kien switch case
            string fruit = "apple";

            switch (fruit)
            {
                case "apple":
                    System.Console.WriteLine("This is an apple.");
                    break;
                case "banana":
                    System.Console.WriteLine("This is a banana.");
                    break;
                case "orange":
                    System.Console.WriteLine("This is an orange.");
                    break;
                default:
                    System.Console.WriteLine("Unknown fruit.");
                    break;
            }

            //switch expression (C# 8.0+)
            string diemso = "A";

            var result = diemso switch
            {
                "A" => "Gioi",
                "B" => "Kha",
                "C" => "Trung Binh",
                _ => "Hoc luc khong xac dinh"
                //_ tuong trung default 
            };

            //Vong lap for
            string s1 = "hello";
            string s2 = "hxlxo";

            int minLength = Math.Min(s1.Length, s2.Length);

            for (int i = 0; i < minLength; i++)
            {
                if (s1[i] == s2[i])
                    System.Console.WriteLine($"Giong tai vi tri {i}: '{s1[i]}'");
                else
                    System.Console.WriteLine($"Khac tai vi tri {i}: '{s1[i]}' vs '{s2[i]}'");
            }

            //Vong lap while
            int d = 1;
            while (d < 5)
            {
                System.Console.WriteLine($"Gia tri cua so la: {d}");
                d++;
                /* return 
                 * Gia tri cua so la: 1
                 * Gia tri cua so la: 2
                 * Gia tri cua so la: 3
                 * Gia tri cua so la: 4
                 */
            }

            //Vong lap do while
            int input;
            do
            {
                Console.Write("Nhap so > 0: ");
                input = Convert.ToInt32(Console.ReadLine());
            } while (input <= 0); // chay it nhat 1 lan

            Console.WriteLine("Ban da nhap: " + input);

            //Vong lap foreach
            Console.WriteLine("Danh sach ten:");
            List<string> names = new List<string> { "Son", "Manh", "Hoang" };
            foreach (string name in names)
            {
                Console.WriteLine("- " + name); // duyet tung phan tu trong danh sach
            }

            //Vong lap long nhau
            Console.WriteLine("Cac cap so (i, j) voi i tu 1 den 2 va j tu 1 den 3:");
            for (int i = 1; i <= 2; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Console.WriteLine($"({i}, {j})");
                }
            }

        }
    }
}



