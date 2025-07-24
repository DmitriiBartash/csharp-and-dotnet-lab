class Program
{
    static void Main()
    {
        var list = new List<int>();

        var i = 10;

        var query = list.Where(x => x == i).Where(x => x < 20);

        list.Add(10);
        list.Add(15);
        list.Add(20);

        i = 15;

        var result = query.ToList();

        list.Clear();

        Console.WriteLine(result.Count);         // ?
        Console.WriteLine(result.FirstOrDefault()); // ?
    }
}
