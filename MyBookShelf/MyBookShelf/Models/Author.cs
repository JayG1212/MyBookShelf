namespace MyBookShelf.Models
{
    public class Author
    {
        // Primary Key
        public int AuthorID { get; set; }
        // Collumn
        public required string AuthorName { get; set; }

        // Navigation property
        public HashSet<Book> Books { get; set; } = new();


    }
}
