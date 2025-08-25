using System;
public class GenericBox<T>
{
    private T _value;

    public GenericBox(T value)
    {
        _value = value;
    }

    public T GetValue()
    {
        return _value;
    }

    public void SetValue(T value)
    {
        _value = value;
    }

    public void Display<U>(U message)
    {
        Console.WriteLine($"Generic Message: {message} | Value: {_value}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        GenericBox<int> intBox = new GenericBox<int>(100);
        Console.WriteLine("IntBox: " + intBox.GetValue());
        intBox.Display<string>("This is an int box");

        GenericBox<string> strBox = new GenericBox<string>("Hello C#");
        Console.WriteLine("StrBox: " + strBox.GetValue());
        strBox.Display<bool>(true);

        GenericBox<DateTime> dateBox = new GenericBox<DateTime>(DateTime.Now);
        Console.WriteLine("DateBox: " + dateBox.GetValue());
        dateBox.Display<double>(3.14159);
    }
}


