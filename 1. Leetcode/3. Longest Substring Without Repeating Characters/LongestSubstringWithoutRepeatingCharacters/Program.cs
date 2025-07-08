
/* Test */ 
public class Solution1
{
    public int LengthOfLongestSubstring(string s)
    {
        int[] lastSeen = new int[128];
        int maxLength = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char currentChar = s[right];
            int ascii = (int)currentChar;

            if (lastSeen[ascii] > left)
            {
                left = lastSeen[ascii];
            }

            maxLength = Math.Max(maxLength, right - left + 1);
            lastSeen[ascii] = right + 1;
        }

        return maxLength;
    }
}

public class Solution2
{
    public int LengthOfLongestSubstring(string s)
    {
        Dictionary<char, int> lastSeen = [];
        int maxLength = 0;
        int left = 0;

        for (int right = 0; right < s.Length; right++)
        {
            char currentChar = s[right];

            if (lastSeen.ContainsKey(currentChar) && lastSeen[currentChar] >= left)
            {
                left = lastSeen[currentChar] + 1;
            }

            lastSeen[currentChar] = right;
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}

public class Program
{
    public static void Main()
    {
        Test(new Solution1(), "abcabcbb", 3);
        Test(new Solution1(), "bbbbb", 1);
        Test(new Solution1(), "pwwkew", 3);
        Test(new Solution1(), "", 0);
        Test(new Solution1(), " ", 1);
        Test(new Solution1(), "dvdf", 3);
        Test(new Solution1(), "anviaj", 5);

        Console.WriteLine();

        Test(new Solution2(), "abcabcbb", 3);
        Test(new Solution2(), "bbbbb", 1);
        Test(new Solution2(), "pwwkew", 3);
        Test(new Solution2(), "", 0);
        Test(new Solution2(), " ", 1);
        Test(new Solution2(), "dvdf", 3);
        Test(new Solution2(), "anviaj", 5);
    }

    public static void Test(dynamic solution, string input, int expected)
    {
        int result = solution.LengthOfLongestSubstring(input);
        Console.WriteLine($"Input: \"{input}\", Output: {result}, Expected: {expected}, Result: {(result == expected ? "PASS" : "FAIL")}");
    }
}