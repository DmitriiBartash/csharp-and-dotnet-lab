class Program
{
    static void Main()
    {
        // Integer literals
        byte byteLiteral = 255;
        short shortLiteral = -32768;
        int intLiteral = 42;
        long longLiteral = 1_000_000_000L;

        // Integer literals in different numeral systems
        int hexLiteral = 0x2A;         // hexadecimal (42)
        int binaryLiteral = 0b00101010; // binary (42)

        // Floating-point literals
        float floatLiteral = 3.14f;
        double doubleLiteral = 2.71828;
        decimal decimalLiteral = 10.5m;

        // Boolean literals
        bool isTrue = true;
        bool isFalse = false;

        // Character literals
        char letterA = 'A';
        char unicodeChar = '\u03A9';   // Greek omega: Ω
        char escapeChar = '\n';        // newline character

        // String literals
        string regularString = "Hello, world!";
        string escapeString = "Line1\nLine2\tTabbed";
        string verbatimString = @"C:\Program Files\MyApp";

        // Null literal
        string nullString = null;

        // Output
        Console.WriteLine("Integers:");
        Console.WriteLine($"byte: {byteLiteral}");
        Console.WriteLine($"short: {shortLiteral}");
        Console.WriteLine($"int: {intLiteral}");
        Console.WriteLine($"long: {longLiteral}");

        Console.WriteLine("\nNumeral systems:");
        Console.WriteLine($"hex (0x2A): {hexLiteral}");
        Console.WriteLine($"binary (0b00101010): {binaryLiteral}");

        Console.WriteLine("\nFloating-point:");
        Console.WriteLine($"float: {floatLiteral}");
        Console.WriteLine($"double: {doubleLiteral}");
        Console.WriteLine($"decimal: {decimalLiteral}");

        Console.WriteLine("\nBoolean:");
        Console.WriteLine($"true: {isTrue}");
        Console.WriteLine($"false: {isFalse}");

        Console.WriteLine("\nCharacters:");
        Console.WriteLine($"char: {letterA}");
        Console.WriteLine($"unicode: {unicodeChar}");
        Console.WriteLine("escape (newline): string\nwith new line");

        Console.WriteLine("\nStrings:");
        Console.WriteLine($"regular: {regularString}");
        Console.WriteLine($"with escaping: {escapeString}");
        Console.WriteLine($"verbatim: {verbatimString}");

        Console.WriteLine("\nNull:");
        Console.WriteLine(nullString ?? "null");
    }
}