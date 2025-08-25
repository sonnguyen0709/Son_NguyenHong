public class Animal
{
    public string Name { get; set; }
    public Animal(string name)
    {
        Name = name;
    }
    public void Eat()
    {
        Console.WriteLine($"{Name} is eating");
    }
    public virtual void Speak()
    {
        Console.WriteLine($"{Name} make a sound");
    }
}

// Dog inherit from Animal
public class Dog : Animal
{
    public Dog(string name) : base(name) { }

    //Override Speak
    public override void Speak()
    {
        Console.WriteLine($"{Name} says: Woof");
    }
    public void Run()
    {
        Console.WriteLine($"{Name} is running");
    }
}

// Puppy inherit from Dog
public class Puppy : Dog
{
    public Puppy(string name) : base(name) { }
    public override void Speak()
    {
        Console.WriteLine($"{Name} says: Yip");
    }
    public void Weep()
    {
        Console.WriteLine($"{Name} is weeping like a puppy");
    }
}

