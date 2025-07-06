/*
    Given an array of integers, determine if there are any duplicates, and if so, return a list of these duplicates (each duplicate only once).
*/

namespace DuplicatesArray
{
    public class Program
    {
        public static void Main()
        {
            int[] numbers = { 1, 2, 3, 2, 4, 5, 1 };

            Console.WriteLine("Start array: " + string.Join(", ", numbers));

            Dictionary<int, int> findDupl = [];
            // Key is the number, value is the count of occurrences

            foreach (int numb in numbers)
            {
                if (findDupl.TryGetValue(numb, out int value))
                {
                    findDupl[numb] = value + 1;
                }
                else
                {
                    findDupl[numb] = 1;
                }
            }

            List<int> duplicates = [];
            foreach (var pair in findDupl)
            {
                if (pair.Value > 1)
                {
                    duplicates.Add(pair.Key);
                }
            }

            Console.WriteLine("Duplicates: " + string.Join(", ", duplicates));
        }
    }
}