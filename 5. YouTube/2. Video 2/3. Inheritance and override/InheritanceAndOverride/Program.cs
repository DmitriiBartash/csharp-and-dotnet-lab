class Program
{
    static void Main(string[] args)
    {
        var childObj = new ChildClass(); // Create a ChildClass object

        childObj.Method1(); // Output: "Child"
        // Method1 is virtual in BaseClass and overridden in ChildClass
        // So this calls the overridden method from ChildClass

        childObj.Method2(); // Output: "Child"
        // Method2 is not virtual; ChildClass defines a new method with the same name
        // Since we're calling it through ChildClass reference, it uses ChildClass version

        LogInfo(childObj); // Pass the object to a method that expects a BaseClass reference
    }

    private static void LogInfo(BaseClass obj)
    {
        obj.Method1(); // Output: "Child"
        // Even though obj is declared as BaseClass, the actual object is ChildClass
        // Because Method1 is virtual and overridden, the ChildClass version is called

        obj.Method2(); // Output: "Base"
        // Method2 is not virtual and was re-declared (hidden) in ChildClass
        // Since obj is a BaseClass reference, the BaseClass version is called
    }
}

public abstract class BaseClass
{
    // Virtual method: allows override in derived classes
    public virtual void Method1()
    {
        Console.WriteLine("Base");
    }

    // Non-virtual method: cannot be overridden
    public void Method2()
    {
        Console.WriteLine("Base");
    }
}

public class ChildClass : BaseClass
{
    // Overrides Method1 from BaseClass
    public override void Method1()
    {
        Console.WriteLine("Child");
    }

    // Hides Method2 from BaseClass (not an override)
    public void Method2()
    {
        Console.WriteLine("Child");
    }
}
