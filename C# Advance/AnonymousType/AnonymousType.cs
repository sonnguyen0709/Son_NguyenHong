using System;

class Program
{
    public static void Main()
    {
        Console.WriteLine("=== 1. Anonymous Type - Basic ===");
        var person = new { Name = "Son", Age = 24 };

        Console.WriteLine($"Name: {person.Name}");
        Console.WriteLine($"Age: {person.Age}");

        Console.WriteLine("\n=== 2. Anonymous Type long nhau ===");
        var employee = new
        {
            Id = 1001,
            Name = "Son",
            Address = new { City = "Ha Noi", District = "Hoang Mai" }
        };
        Console.WriteLine($"ID: {employee.Id}");
        Console.WriteLine($"Name: {employee.Name}");
        Console.WriteLine($"City: {employee.Address.City}");
        Console.WriteLine($"District: {employee.Address.District}");

        Console.WriteLine("\n=== 3. Mang cac Anonymous Type ===");
        var students = new[]
        {
            new { Id = 1, Name = "Son" },
            new { Id = 2, Name = "Manh" },
            new { Id = 3, Name = "Dung" }
        };

        foreach (var student in students)
        {
            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
        }
    }
}