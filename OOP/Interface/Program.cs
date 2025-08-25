public class Program
{
    static void Main()
    {
        Car car = new Car("Toyota");
        SmartCar smartCar = new SmartCar("Poscher");

        Console.WriteLine("Car: ");
        car.StartEngine();
        car.Move();
        Console.WriteLine();
        Console.WriteLine("Smart car: ");
        smartCar.StartEngine();
        smartCar.Move();
        smartCar.ConnectToNetwork();
        smartCar.SelfDrive();
        Console.WriteLine();

        Console.WriteLine("Explicit: ");
        StartMachine machine = new StartMachine("Machine-X");
        //Can't invoke Start()
        //machine.Start();
        IEngine enginePart = machine;
        enginePart.Start();
        ISystem systemPart = machine;
        systemPart.Start();
        machine.ShowStatus();

    }
}