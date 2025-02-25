using System.ComponentModel.DataAnnotations;

namespace MyBookShelf.Models
{
    public class Book
    {
        // Primary Key
        public int ID { get; set; }

        // Columns
        public required string Title { get; set; }
        public int Pages { get; set; }
        public int PublicationYear { get; set; }

        // Foreign Keys
        public int AuthorID { get; set; }
        public int GenreID { get; set; }
        public int ShelfID { get; set; }


        // Navigation Properties
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public Shelf Shelf { get; set; }



    }
}
