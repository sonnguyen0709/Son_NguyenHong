public interface IEngine
{
    void Start();
}
public interface ISystem
{
    void Start();
}
public class StartMachine : IEngine, ISystem
{
    public string Name { get; set; }
    public StartMachine(string name)
    {
        Name = name;
    }
    void IEngine.Start()
    {
        Console.WriteLine($"{Name}: Engine is starting");
    }
    void ISystem.Start()
    {
        Console.WriteLine($"{Name}: System is starting");
    }
    public void ShowStatus()
    {
        Console.WriteLine($"{Name} is ready");
    }
}