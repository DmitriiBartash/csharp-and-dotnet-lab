namespace Two_Sum
{
    public class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            var numIndices = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (numIndices.TryGetValue(complement, out int index))
                {
                    return [index, i];
                }
                numIndices[nums[i]] = i;
            }

            throw new ArgumentException("No valid two-sum solution found.");
        }
    }

    /* Test class */
    public class SolutionTest
    {
        public static void RunTests()
        {
            // Test 1
            int[] result1 = Solution.TwoSum([2, 7, 11, 15], 9);
            Console.WriteLine($"Test 1: [{string.Join(", ", result1)}]"); // Expected: [0, 1]

            // Test 2
            int[] result2 = Solution.TwoSum([3, 2, 4], 6);
            Console.WriteLine($"Test 2: [{string.Join(", ", result2)}]"); // Expected: [1, 2]

            // Test 3
            int[] result3 = Solution.TwoSum([3, 3], 6);
            Console.WriteLine($"Test 3: [{string.Join(", ", result3)}]"); // Expected: [0, 1]

            // Test 4 (no solution)
            try
            {
                int[] result4 = Solution.TwoSum([1, 2, 3], 7);
                Console.WriteLine($"Test 4: [{string.Join(", ", result4)}]");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test 4: Exception - {ex.Message}");
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            SolutionTest.RunTests();
        }
    }
}
