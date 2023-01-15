using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Viewer.Models;

namespace Viewer.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reviewer> Reviewers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AuthorConfig(modelBuilder);
            BooksConfig(modelBuilder);
            GenreConfig(modelBuilder);
            ReviewConfig(modelBuilder);
            ReviewerConfig(modelBuilder);
        }
        private static void AuthorConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasMany(author => author.Books);
        }
        private static void BooksConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasOne(book => book.Genre).WithMany(books => books.Books);
            modelBuilder.Entity<Book>().HasOne(genre => genre.Author).WithMany(books => books.Books);
            modelBuilder.Entity<Book>().HasMany(review => review.Reviews);
        }
        private static void GenreConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasMany(books => books.Books);
        }
        private static void ReviewConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasOne(reviwer => reviwer.Reviewer).WithMany(review => review.Reviews);
        }

        private static void ReviewerConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reviewer>().HasMany(reviews => reviews.Reviews);
        }
    }
}
