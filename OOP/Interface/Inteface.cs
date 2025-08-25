// Initialize interface
public interface IName
{
    string Name { get; set; }
}
public interface IMoveable
{
    void Move();
}

// An interface can inherit from other interface
public interface IVehicle : IMoveable
{
    void StartEngine();
}
public interface IConnectable
{
    void ConnectToNetwork();
}

public interface IAutonomous
{
    void SelfDrive();
}
 
// A class can inherit from many interface
public class Car : IName, IVehicle
{
    public string Name { get; set; }
    public Car(string name)
    {
        Name = name;
    }

    public void Move()
    {
        Console.WriteLine($"{Name} is moving.");
    }

    public void StartEngine()
    {
        Console.WriteLine($"{Name} engine started.");
    }
}

// A class can inherit from a class and many interface
public class SmartCar : Car, IConnectable, IAutonomous
{
    public SmartCar(string name) : base(name) { }

    public void ConnectToNetwork()
    {
        Console.WriteLine($"{Name} connected to the internet.");
    }

    public void SelfDrive()
    {
        Console.WriteLine($"{Name} is driving autonomously.");
    }
}
