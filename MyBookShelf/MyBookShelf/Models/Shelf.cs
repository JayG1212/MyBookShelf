namespace MyBookShelf.Models
{
    public class Shelf
    {
        public int ShelfID { get; set; } // Primary key
        
        // Columns
        public required string ShelfName { get; set; }

        // Navigation Property
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
