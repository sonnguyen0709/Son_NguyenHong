using System;
using System.Collections.Generic;
interface IPerson
{
    string Name { get; set; }
    void ShowInfo();
}
class Student : IPerson
{
    public string Name { get; set; }
    public double Grade { get; set; }
    public void ShowInfo()
    {
        Console.WriteLine($"Student: {Name}, Grade: {Grade}");
    }
}
class Teacher : IPerson
{
    public string Name { get; set; }
    public string Subject { get; set; }
    public void ShowInfo()
    {
        Console.WriteLine($"Teacher: {Name}, Subject: {Subject}");
    }
}
class PersonManager<T> where T : class, IPerson, new()
{
    private List<T> people = new List<T>();
    public void AddPerson(T person)
    {
        people.Add(person);
    }
    public void PrintAll()
    {
        Console.WriteLine("Danh sach: ");
        foreach (var person in people)
        {
            person.ShowInfo();
        }
    }
    public T FindByName(string name)
    {
        foreach (var person in people)
        {
            if (person.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                return person;
        }
        return null;
    }
}
class Program
{
    static void Main()
    {
        var studentManager = new PersonManager<Student>();
        var teacherManager = new PersonManager<Teacher>();
        Console.WriteLine("Nhap so sinh vien: ");
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Student s = new Student();
            Console.Write($"Ten sinh vien thu {i + 1}: ");
            s.Name = Console.ReadLine();
            Console.Write($"So diem cua sinh vien: ");
            s.Grade = int.Parse (Console.ReadLine());
            studentManager.AddPerson(s);
            Console.Clear();
        }
        Console.WriteLine("Nhap so giao vien: ");
        int m = int.Parse(Console.ReadLine()); 
        for (int i = 0;i < m; i++)
        {
            Teacher t = new Teacher();
            Console.Write($"Ten giao vien thu {i + 1}: ");
            t.Name = Console.ReadLine();
            Console.Write($"Bo mon giao vien giang day: ");
            t.Subject = Console.ReadLine();
            teacherManager.AddPerson(t);
            Console.Clear();
        }
        studentManager.PrintAll();
        Console.ReadKey();
        Console.Clear();
        teacherManager.PrintAll();
        Console.ReadKey();
        Console.Clear();
        Console.Write("\nTim kiem sinh vien theo ten: ");
        string nameSearch = Console.ReadLine();
        var found = studentManager.FindByName(nameSearch);
        if (found != null)
        {
            Console.Write("Ket qua: ");
            found.ShowInfo();
        }
        else
        {
            Console.WriteLine("Khong tim thay");
        }
    }
}
