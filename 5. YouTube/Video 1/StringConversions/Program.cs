namespace StringConversions
{
    public class StringConversions
    {
        static void Main()
        {
            var s1 = "Text"; // s1 references the string literal "Text"
            var s2 = s1;     // s2 now references the same string as s1 ("Text")
            var s3 = "Text"; // s3 also references the same interned string "Text"

            Console.WriteLine(s1 == s3);
            // True — all three point to the same interned string "Text"

            s2 += " Changed";
            // s2 is now assigned a new string "Text Changed"
            // s1 remains "Text" because strings are immutable

            ChangeString(s1);
            // s1 is passed by value; inside the method, a new string is created,
            // but it does NOT affect the original s1 outside the method

            Console.WriteLine(s1 == s2);
            // False — s1 is still "Text", s2 is "Text Changed"
        }

        private static void ChangeString(string str)
        {
            str += " Changed";
            // This creates a new string, but since 'str' is a local copy,
            // the change has no effect outside this method
        }
    }
}
