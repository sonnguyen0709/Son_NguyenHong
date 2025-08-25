using System;
class Program
{
    static void PrintInfo(dynamic value)
    {
        Console.WriteLine($"Gia tri : {value}");
        Console.WriteLine($"Kieu du lieu thuc te : {value.GetType()}");

        if (value is string)
        {
            Console.WriteLine("In hoa " + value.ToUpper());
        }
        else if (value is int)
        {
            Console.WriteLine("Cong them 10 " + (value + 10));
        }
        else if (value is DateTime)
        {
            Console.WriteLine("Ngay : " + value.ToShortDateString());
        }

        Console.WriteLine();
    }

    static dynamic GetDynamicValue(string type)
    {
        return type switch
        {
            "text" => "Hello",
            "number" => 12345,
            "date" => DateTime.Now,
            _ => null
        };
    }

    static void Main()
    {
        Console.WriteLine("== Demo Method nhan dynamic ==");
        PrintInfo("Hello world");
        PrintInfo(42);
        PrintInfo(DateTime.Today);

        Console.WriteLine("== Demo Method tra ve dynamic ==");
        dynamic result = GetDynamicValue("text");
        Console.WriteLine("Ket qua text: " + result);

        result = GetDynamicValue("number");
        Console.WriteLine("Ket qua number + 5: " + (result + 5));

        result = GetDynamicValue("date");
        Console.WriteLine("Ket qua date: " + result.ToLongDateString());
    }
}
