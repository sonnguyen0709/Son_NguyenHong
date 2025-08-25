public class Animal
{
    public string Name { get; set; }
    public Animal(string name)
    {
        Name = name;
    }
    public virtual void Speak()
    {
        Console.WriteLine($"{Name} makes a sound.");
    }
    public void Info()
    {
        Console.WriteLine("This is an animal.");
    }

    // Compile-time Polymorphism
    public void Info(string extra)
    {
        Console.WriteLine($"This is an animal: {extra}");
    }
}
public class Cow : Animal
{
    public Cow(string name) : base(name) { }
    public override void Speak()
    {
        Console.WriteLine($"{Name} mouw.");
    }

    // Compile-time Polymorphism
    public void Info(int age)
    {
        Console.WriteLine($"{Name} is {age} years old.");
    }
}
class Program
{
    static void Main()
    {
        Cow cow = new Cow("Rex");
        cow.Info();
        cow.Info("very heavy");
        cow.Info(10);
        Console.WriteLine();

        Animal myAnimal = new Cow("Buddy");
        myAnimal.Speak();

    }
}
