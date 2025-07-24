namespace LinqDeferredExecution
{
    internal class Solution
    {
        public static void Run()
        {
            // Create an empty list of integers
            var list = new List<int>();

            // Declare a variable i with initial value 10
            var i = 10;

            // Define a deferred LINQ query
            // At this point, the query is NOT executed
            var query = list.Where(x => x == i).Where(x => x < 20);

            // Add values to the list
            list.Add(10);
            list.Add(15);
            list.Add(20);

            // Update the variable i → now i = 15
            // Because i is captured in a closure, the query will use the new value
            i = 15;

            // Execute the query — ToList() triggers evaluation and materializes results
            // Now it's effectively: list.Where(x => x == 15).Where(x => x < 20)
            // Only the value 15 satisfies both conditions
            var result = query.ToList(); // result = { 15 }

            // Clear the original list — this has no effect on the already materialized result
            list.Clear();

            // Output the results
            Console.WriteLine(result.Count);         // 1
            Console.WriteLine(result.FirstOrDefault()); // 15
        }
    }
}
