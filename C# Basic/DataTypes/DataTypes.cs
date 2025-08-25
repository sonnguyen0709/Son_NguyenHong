using System;
using System.Text;

namespace DataTypes
{
    //Enum : dinh nghia cac trang thai (dang hang so co ten)
    enum Status
    {
        Pending,
        InProgress,
        Completed
    }

    //Struct : kieu du lieu do nguoi dung dinh nghia de thuan tien cho viec quan ly du lieu
    struct Task
    {
        public string Name;
        public int Priority;
        public Status CurrentStatus;

        public void Display()
        {
            Console.WriteLine($"Task: {Name} | Priority: {Priority} | Status: {CurrentStatus}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Kieu so nguyen
            byte b = 255;
            short s = -32000;
            int i = 123456;
            long l = 1234567890123L;

            //Kieu so thuc
            float f = 3.14f;
            double d = 3.14159265358979;
            decimal dec = 12345.6789m;

            //Kieu logic
            bool isActive = true;

            //Kieu ky tu
            char c = 'A';
            Console.WriteLine("====== Cac kieu du lieu co ban trong C# ======\n");

            Console.WriteLine($"byte: {b}");
            Console.WriteLine($"short: {s}");
            Console.WriteLine($"int: {i}");
            Console.WriteLine($"long: {l}");

            Console.WriteLine($"\nfloat: {f}");
            Console.WriteLine($"double: {d}");
            Console.WriteLine($"decimal: {dec}");

            Console.WriteLine($"\nbool: {isActive}");
            Console.WriteLine($"char: {c}");

            Console.WriteLine("\n==============================================");
            Console.ReadLine();
            Console.WriteLine("====== Cac kieu du lieu nang cao trong C# ======\n");

            //1.struct va enum
            Task myTask = new Task
            {
                Name = "C# DataTypes",
                Priority = 1,
                CurrentStatus = Status.InProgress
            };
            myTask.Display();

            //2.StringBuilder : dung de xay dung chuoi dai
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("\n== Nhat ky cong viec ==");
            sb.AppendLine("09:00 - C# DataTypes");
            sb.AppendLine("11:00 - String");
            sb.AppendLine("14:00 - DateTImes");
            Console.WriteLine(sb.ToString());

            //3.Anonymous type: tao doi tuong khong can dinh nghia class
            var user = new { Name = "Son", Age = 22, IsActive = true };
            Console.WriteLine($"User: {user.Name}, Age: {user.Age}, Active: {user.IsActive}");
        }
    }
}
