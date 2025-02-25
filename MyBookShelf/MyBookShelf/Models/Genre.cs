namespace MyBookShelf.Models
{
    public class Genre
    {
        // Primary Key
        public int GenreID { get; set; }

        // Collumns
        public required string GenreName { get; set; }


        // Navigation property
        public HashSet<Book> Books { get; set; } = new();
    }
}
