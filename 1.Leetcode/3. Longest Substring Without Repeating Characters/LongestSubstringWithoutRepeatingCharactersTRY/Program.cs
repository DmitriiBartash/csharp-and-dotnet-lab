namespace LongestSubstringWithoutRepeatingCharactersTRY
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var solution = new Solution();

            Test(solution, "abcabcbb", 3);  // "abc"
            Test(solution, "bbbbb", 1);     // "b"
            Test(solution, "pwwkew", 3);    // "wke"
            Test(solution, "", 0);          // ""
            Test(solution, " ", 1);         // " "
            Test(solution, "dvdf", 3);      // "vdf"
        }

        public static void Test(Solution solution, string input, int expected)
        {
            int result = solution.LengthOfLongestSubstring(input);
            Console.WriteLine($"Input: \"{input}\" | Output: {result} | Expected: {expected} | {(result == expected ? "PASS" : "FAIL")}");
        }
    }

    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            int[] array = new int[128];
            int maxLength = 0;
            int left = 0;

            for (int right = 0; right < s.Length; right++)
            {
                char currentChar = s[right];
                int ascii = (int)currentChar;

                if (array[ascii] > left)
                {
                    left = array[ascii];
                }

                maxLength = Math.Max(maxLength, right - left + 1);
                array[ascii] = right + 1;
                    
            }

            return maxLength;
        }
    }
}
