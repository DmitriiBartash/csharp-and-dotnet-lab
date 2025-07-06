namespace Book
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("This is a book demo");

            // Create a Book
            var myBook = new Book("1984", "George Orwell", 1949, false);

            // Output information about the book
            Console.WriteLine(myBook.ToString());

            // Mark as read
            myBook.MarkAsRead();

            // Output updated information
            Console.WriteLine(myBook.ToString());
        }

        public class Book(string Title, string Author, int PublicationYear, bool IsRead)
        {
            public string Title { get; set; } = Title;
            public string Author { get; set; } = Author;
            public int PublicationYear { get; set; } = PublicationYear;
            public bool IsRead { get; set; } = IsRead;

            public void MarkAsRead()
            {
                IsRead = true;
            }

            public override string ToString()
            {
                if (IsRead)
                {
                    return $"Author: {Author}, Year: {PublicationYear} - Read";
                }
                else
                {
                    return $"Author: {Author}, Year: {PublicationYear} - Not Read";
                }
            }
        }
    }
}
