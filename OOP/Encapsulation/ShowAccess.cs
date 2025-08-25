public class BaseClass
{
    private string privateFields = "private";
    protected string protectedField = "protected";
    internal string internalField = "internal";
    protected internal string protectedInternalField = "protectedinternal";
    public string publicField = "public";
    public void ShowMember()
    {
        Console.WriteLine("Base class: ");
        Console.WriteLine(privateFields);
        Console.WriteLine(protectedField);
        Console.WriteLine(protectedInternalField);
        Console.WriteLine(internalField);
        Console.WriteLine(publicField);
    }
}

// Derived class
public class DerivedClass : BaseClass
{
    public void ShowAccess()
    {
        Console.WriteLine("Derived class: ");
        // Console.WriteLine(privateFields);
        // Can't access: private
        Console.WriteLine(protectedField);
        Console.WriteLine(protectedInternalField);
        Console.WriteLine(internalField);
        Console.WriteLine(publicField);
    }
}

// Other class
public class OtherClass
{
    public void ShowAccess()
    {
        var obj = new BaseClass();
        Console.WriteLine("Other class: ");
        // Console.WriteLine(obj.privateField);
        // Can't access: private
        // Console.WriteLine(obj.protectedField);
        // Can't access: not inheritance
        Console.WriteLine(obj.internalField);
        Console.WriteLine(obj.protectedInternalField);
        Console.WriteLine(obj.publicField);
    }
}

