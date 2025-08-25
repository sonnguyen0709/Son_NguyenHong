using System;

public class TemperatureSensor
{
    public delegate void OverheatHandler(double currentTemp);

    public event OverheatHandler Overheated;

    public void CheckTemperature(double temperature)
    {
        Console.WriteLine($"Current Temperature: {temperature}°C");

        if (temperature > 37.5)
        {
            Overheated?.Invoke(temperature);
        }
    }
}

public class Program
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();

        sensor.Overheated += OnOverheated;

        sensor.CheckTemperature(36.0);
        sensor.CheckTemperature(38.2);
    }

    static void OnOverheated(double temp)
    {
        Console.WriteLine($"Overheat detected: {temp}°C");
    }
}