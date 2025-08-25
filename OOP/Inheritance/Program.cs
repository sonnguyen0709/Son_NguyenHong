class Program
{
    static void Main()
    {
        Console.WriteLine("Animal: ");
        Dog dog = new Dog("Lu");
        Puppy puppy = new Puppy("Pu");

        dog.Run();
        dog.Speak();
        puppy.Run();
        puppy.Speak();
        puppy.Weep();
        Console.WriteLine();

        Console.WriteLine("GetArea: ");
        Rectangle rectangle = new Rectangle("Rectangle A", 10.5, 6.5);
        Square square = new Square("Square B", 6.5);
        Console.WriteLine($"{rectangle.Name} has area: {rectangle.GetArea()}");
        Console.WriteLine($"{square.Name} has area: {square.GetArea()}");

    }
}