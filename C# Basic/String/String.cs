using System;

namespace DataTypeString
{
    class Program
    {
        static void Main()
        {

            /* 
             * Mot so kieu escape sequence 
             * \' : dau nhay don
             * \\ : dau backslash
             * \0 : null
             * \a : canh bao ( alert )
             * \b : xoa lui ( backspace )
             * \n : dong moi
             * \r : quay ve dau dong
             * \t : tab ngang
             * \v : tab doc
             */

            //Khoi tao string tu 1 mang ky tu
            char[] letters = { 'S', 'o', 'n' };
            string name = new string(letters);

            //Khoi tao string tu 1 phan mang ky tu
            char[] letters1 = { 'S', 'o', 'n', ' ', 'N', 'g', 'u', 'y', 'e', 'n', 'M' };
            string names = new string(letters1, 0, 10);

            //Khoi tao string bang cach lap lai ky tu
            string aaa = new string('a', 10);

            //Khoi tao chuoi trong
            string empty = string.Empty;

            //Phep toan kieu chuoi
            string str1 = "Son" + " Nguyen";
            System.Console.WriteLine(str1);

            string son = "Son", nguyen = "Nguyen";
            string name1 = son + " " + nguyen;
            System.Console.WriteLine(name1);

            string str3 = "Son";
            str3 += " ";
            str3 += "Nguyen";
            System.Console.WriteLine(str3);

            //Do dai cua chuoi//
            Console.WriteLine($"Do dai cua chuoi {name.Length}.");

            //Kiem tra chuoi co bao gom
            Console.WriteLine($"Kiem tra co ky tu S hay khong {name.Contains('S')}.");

            //Kiem tra chuoi bat dau hay ket thuc bang
            Console.WriteLine($"Chuoi bat dau bang S : {name.StartsWith('S')}.");
            Console.WriteLine($"Chuoi ket thuc bang S : {name.EndsWith('S')}.");

            //So sanh xau ky tu
            string manh = "Manh";
            Console.WriteLine($"So sanh xau ky tu : {manh.Equals(manh)}.");

            //Chuyen chu hoa, chu thuong
            Console.WriteLine($"Chuyen thanh chu hoa : {name.ToUpper()}.");
            Console.WriteLine($"Chuyen thanh chu thuong : {name.ToLower()}.");

            //Cat bo khoang trang
            string name2 = "   Son Nguyen\n  ";
            System.Console.WriteLine($"Cat bo khoang trang : {name2.Trim()}.");

            //TrimEnd cat bo khoang trang cuoi chuoi, TrimStart cat khoang trang o dau, Trim cat giua 2 ky tu
            Console.WriteLine($"Cat giua hai ky tu : {name.Trim(new[] { 'S', 'n' })}.");

            //Cat chuoi giua 2 vi tri
            string sub = names.Substring(0, 3);
            Console.WriteLine("Cat chuoi: " + sub);

            //Tim vi tri cua chuoi con
            int index = names.IndexOf('S');
            Console.WriteLine("Vi tri cua 'S': " + index);

            //Thay the chuoi
            string replace = name.Replace("Son", "Nguyen");
            Console.WriteLine("Sau khi thay 'Son' thanh 'Nguyen' :");
            Console.WriteLine(replace);

            //Tach chuoi
            string list = "Son,Nguyen,Hong";
            string[] listName = list.Split(',');
            Console.WriteLine("Danh sach ten:");
            foreach (string lN in listName)d
            {
                Console.WriteLine("- " + lN);
            }

            //Xoa 4 ky tu tu vi tri 0
            string remove = names.Remove(0, 4);
            Console.WriteLine("Sau khi Remove(0,4): " + remove);

            //Chen chuoi vao vi tri
            string insert = names.Insert(10, " Hong");
            Console.WriteLine("Sau khi chen vao vi tri 9: " + insert);

            //So sanh hai chuoi 
            string s1 = "abc";
            string s2 = "ABC";
            int result1 = string.Compare(s1, s2); //Phan biet chu hoa
            int result2 = string.Compare(s1, s2, true); //Khong phan biet chu hoa
            Console.WriteLine("\nCompare phan biet chu hoa: " + result1); // khac → kq != 0
            Console.WriteLine("Compare khong phan biet chu hoa: " + result2); // giong → kq = 0
                                                                              //Ghep cac chuoi con thanh mot chuoi
            string[] arrayName = { "Son", "Nguyen", "Hong" };
            string result3 = string.Concat(arrayName);
            Console.WriteLine("\nKet qua noi chuoi bang Concat: " + result3);

            //Dung Join giong Concat nhung tu noi chuoi bang dau phan cach
            string result4 = string.Join(" ", arrayName);
            Console.WriteLine("\nKet qua noi chuoi bang Join: " + result4);

            //String Interpolation : tao chuoi tu gia tri cua bien
            Console.WriteLine($"Ten cua ban la {names}.");
        }
    }
}













