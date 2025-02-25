using Microsoft.EntityFrameworkCore;
using MyBookShelf.Models;
using System.Linq;
using System.Threading.Tasks;


namespace MyBookShelf.Data
{
    public class DbInitializer
    {

        public static async Task Initialize(ApplicationDbContext context)
        {
            await context.Database.MigrateAsync();

            // Look for any students.
            if (await context.Books.AnyAsync())
            {
                return;   // DB has been seeded
            }
            // Ensure related Author exist first
            var author = new Author { AuthorName = "Herman Melville" };
            // Add and save related Author
            context.Authors.Add(author);
            await context.SaveChangesAsync(); // Save to generate AuthorID



            // Add multiple genres
            var genres = new Genre[]
            {
                new Genre { GenreName = "Fiction" },
                new Genre { GenreName = "Non-Fiction" },
                new Genre { GenreName = "Science Fiction" },
                new Genre { GenreName = "Fantasy" },
                new Genre { GenreName = "Mystery"},
                new Genre { GenreName = "Science"},
                new Genre { GenreName = "Philosophy"},
                new Genre { GenreName = "Theology/Religion"},
                new Genre { GenreName = "History"}

            };

            context.Genres.AddRange(genres); // Add the genres in bulk
            await context.SaveChangesAsync(); // Save to generate IDs for genres


            // Add multiple shelves
            var shelves = new Shelf[]
            {
                new Shelf { ShelfName = "Read" },
                new Shelf { ShelfName = "Not Read" },
            };

            context.Shelves.AddRange(shelves); // Add the shelves in bulk
            await context.SaveChangesAsync(); // Save to generate IDs for shelves

            // Retrieves ID's for Fiction and Read (Which are both 1)
            var fictionGenre = await context.Genres.FirstAsync(g => g.GenreName == "Fiction");
            var readShelf = await context.Shelves.FirstAsync(s => s.ShelfName == "Read");


            var book = new Book
            {
                Title = "Moby Dick",
                PublicationYear = 1851,
                Pages = 625,
                AuthorID = author.AuthorID,
                GenreID = fictionGenre.GenreID,
                ShelfID = readShelf.ShelfID
            };

            context.Books.Add(book);
            await context.SaveChangesAsync(); // Save the book



        }
    }
}
