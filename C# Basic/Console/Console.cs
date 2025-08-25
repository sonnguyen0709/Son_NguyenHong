using System;

namespace ConsoleCommand
{
    class Program
    {
        static void Main()
        {
            //Thiet lap tieu de cua so console
            Console.Title = "Vi du ve Console trong C#";

            //Doi mau chu thanh vang
            Console.ForegroundColor = ConsoleColor.Yellow;

            //Mau nen la xanh duong
            Console.BackgroundColor = ConsoleColor.Blue;

            //Cap nhat mau nen tren toan bo cua so
            Console.Clear();

            //in ra mot so nguyen
            Console.WriteLine(7);

            //in ra mot so thuc
            Console.WriteLine(9.0);

            //in ra mot gia tri logic
            Console.WriteLine(true);

            //in ra mot bien kieu so nguyen
            int a = 100;
            Console.WriteLine(a);

            //in ra 1 bien kieu logic
            bool b = false;
            Console.WriteLine(b);

            //in ra 1 bien kieu xau ky tu
            string c = "Ten toi la Son";

            Console.WriteLine(c);
            //in chu nhung khong xuong dong
            Console.Write("Nhap ten cua ban: ");

            //doc mot dong nhap tu nguoi dung
            string ten = Console.ReadLine();

            //in ra mot chuoi
            Console.WriteLine("Chao ban " + ten + "!");

            //dung chuong trinh den khi nguoi dung bam phim
            Console.ReadKey();

            //reset mau ve mac dinh
            Console.ResetColor();
        }
    }
}



