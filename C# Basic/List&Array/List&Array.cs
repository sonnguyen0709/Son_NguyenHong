using System;

namespace ListArray
{
    class Program
    {
        static void Main()
        {
            //Khoi tao mang soNguyen
            int[] soNguyen = new int[5] { 1, 3, 5, 7, 9 };

            //Gan phan tu cho mang
            soNguyen[4] = 10;

            //Duyet phan tu cua mang voi foreach hoac for
            Console.WriteLine("Cac phan tu trong mang:");
            for (int i = 0; i < soNguyen.Length; i++)
            {
                Console.WriteLine($"Phan tu thu {i} cua mang : {soNguyen[i]}");
            }

            Console.WriteLine("Duyet mang bang foreach:");
            foreach (int x in soNguyen)
            {
                Console.WriteLine(x);
            }

            //Mang hai chieu
            //Khoi tao mang voi 3 dong, 4 cot
            int[,] mang2Chieu = new int[3, 4]
            {
            { 1, 2, 3, 4 },
            { 5, 6, 7, 8 },
            { 9, 10, 11, 12 }
            };

            //Gan lai phan tu cho mang
            mang2Chieu[0, 0] = 0;

            //Duyet mang bang vong lap for
            Console.WriteLine("\nCac phan tu trong mang 2 chieu:");
            for (int i = 0; i < mang2Chieu.GetLength(0); i++) // Duyet dong
            {
                for (int j = 0; j < mang2Chieu.GetLength(1); j++) // Duyet cot
                {
                    Console.Write(mang2Chieu[i, j] + "\t");
                }
                Console.WriteLine();
            }

            //Mang rang cua: La mang 1 chieu, moi phan tu cua mang la 1 mang 1 chieu khac
            int[][] jArray = new int[3][];
            jArray[0] = new int[] { 0, 1, 2 };
            jArray[1] = new int[] { 1, 2, 3, 4 };
            jArray[2] = new int[] { 1, 2 };

            //Duyet mang bang for, foreach
            Console.WriteLine("Duyet mang rang cua bang for:");
            for (int i = 0; i < jArray.Length; i++)
            {
                for (int j = 0; j < jArray[i].Length; j++)
                {
                    Console.Write(jArray[i][j] + " ");
                }
                Console.WriteLine();
            }

            //ArrayList
            //La list ma cac phan tu mang type object
            //List chua moi kieu du lieu cua C#
            //Khoi tao Arraylist
            ArrayList danhSach = new ArrayList();

            //Them phan tu vao list
            danhSach.Add(100);                 // So nguyen
            danhSach.Add("Xin chao");          // Chuoi
            danhSach.Add(3.14);                // So thuc
            danhSach.Add(true);                // Bool
            Console.WriteLine("Danh sach ban dau:");

            //Duyet list bang for, foreach
            foreach (var item in danhSach)
            {
                Console.WriteLine(item);
            }

            //Generic List (List<>)
            //Cac phan tu List co cung kieu du lieu
            //Khoi tao list
            var numbers = new List<int>() { 1, 2, 3, 4, 5, 2 };

            //Truy xuat phan tu trong list
            Console.WriteLine($"Phan tu thu nhat cua list la: {numbers[0]}");

            //Duyet phan tu trong list voi for hoac foreach
            int sumOfnumbers = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                Console.WriteLine($"Phan tu thu nhat cua list la: {numbers[i]}");
            }
            foreach (int i in numbers)
            {
                sumOfnumbers += i;
            }
            Console.WriteLine($"Tong cac phan tu cua list la: {sumOfnumbers}");

            //Thao tac voi list
            //Xoa phan tu co gia tri 1
            numbers.Remove(1);

            //Xoa phan tu vi tri thu 1
            numbers.RemoveAt(1);

            //Tim so luong phan tu
            int counts = numbers.Count; //counts = 5

            //Xac dinh gia tri co nam trong danh sach
            bool kt = numbers.Contains(1); //true

            //Xac dinh vi tri dau cua phan tu trong List
            int index = numbers.IndexOf(1); //0

            //Chuyen doi List thanh Array
            int[] ints = numbers.ToArray();
        }
    }
}




        