// Initialize abstract class
public abstract class Shape
{
    public string Name { get; set; }
    public Shape(string name)
    {
        Name = name;
    }
    public abstract double GetArea();
}
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }
    public Rectangle(string name, double width, double height) : base(name)
    {
        Width = width;
        Height = height;
    }

    // Abstract member must be overridden
    public override double GetArea()
    {
        return Width * Height;
    }
}
public sealed class Square : Rectangle
{
    public Square(string name, double size) : base(name, size, size) { }
}
// public class Hexagon : Square { }
// Hexagon cannot derive from sealed type Square
