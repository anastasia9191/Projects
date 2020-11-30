using Microsoft.EntityFrameworkCore;

namespace MyLibraryApp.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public BookContext(DbContextOptions<BookContext> options)
                : base(options)
        {
         //   Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookAuthor>()
            .HasKey(x => new { x.BookId, x.AuthorId });

        }
    }
}