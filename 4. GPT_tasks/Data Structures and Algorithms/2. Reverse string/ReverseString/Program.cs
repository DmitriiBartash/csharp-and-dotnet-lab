// ===============================================
// Task: Reverse a String
// -----------------------------------------------
// Problem:
// You are given a string. 
// Write code that returns the reversed version of that string — 
// that is, all the characters in reverse order.
//
// Example:
// Input:  "hello"
// Output: "olleh"
// ===============================================


class Program
{
    static void Main()
    {
        // Option 1: Using a for loop (manual reverse)
        // Loop through the string backwards and build a new reversed string
        string input = "hello";
        string reverse1 = "";

        for (int i = 0; i < input.Length; i++)
        {
            reverse1 += input[input.Length - 1 - i];
        }

        Console.WriteLine(reverse1);

        // Option 2: Using char[] + Array.Reverse()
        // Convert string to array of characters, reverse the array in-place, then make a new string
        char[] chars = input.ToCharArray();
        Array.Reverse(chars);
        string reverse2 = new(chars);
        Console.WriteLine("Reversed: " + reverse2);

        // Option 3: Using LINQ .Reverse()
        // Use LINQ to reverse the characters and convert the result to a string
        //string reverse3 = new(input.Reverse().ToArray());
        string reverse3 = new([.. input.Reverse()]);
        Console.WriteLine("Reversed: " + reverse3);

    }
}