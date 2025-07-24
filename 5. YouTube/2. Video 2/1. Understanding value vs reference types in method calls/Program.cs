public class MyClass
{
    public int Num { get; set; }
}

public struct MyStruct
{
    public int Num { get; set; }
}

public class Program
{
    static void Main()
    {
        var myClassObj = new MyClass();  // an object is created on the HEAP, myClassObj is a reference
        var myStructObj = new MyStruct(); // a copy of the struct is created on the STACK

        MethodA(myClassObj.Num);
        // Num = 0 (by default)
        // num = num + 1 - but this is a local copy, it is not returned
        // does not affect myClassObj.Num
        // myClassObj.Num = 0

        MethodB(myStructObj);
        // MyStruct - value type - a copy is passed
        // myStruct.Num +=1 - the copy is changed, the original is untouched
        // Does not affect myStructObj.Num

        MethodC(myClassObj);
        // myClassObj.Num += 1 - now Num = 1
        // This changes the object itself in the Heap
        // Num = 1

        MethodD(myClassObj);
        // myClass = new MyClass { Num = myClass.Num * 2}
        // This is just a reassignment of the local variable myClass
        // Outside Main, myClassObj does not change

        Console.WriteLine(myClassObj.Num); // 1
        Console.WriteLine(myStructObj.Num); // 0

    }

    private static void MethodA(int num)
    {
        num = num + 1;
    }

    private static void MethodB(MyStruct myStruct)
    {
        myStruct.Num += 1;
    }

    private static void MethodC(MyClass myClass)
    {
        myClass.Num += 1;
    }

    private static void MethodD(MyClass myClass)
    {
        myClass = new MyClass
        {
            Num = myClass.Num * 2
        };
    }

    // To actually change the reference (i.e., assign a new object and reflect that change outside the method),
    // we must pass the parameter using the 'ref' keyword.
    // This allows the method to modify the caller's reference, not just the local copy.
    // Example usage:
    // MethodD(ref myClassObj);
    // and the method signature must be:
    // private static void MethodD(ref MyClass myClass)
}