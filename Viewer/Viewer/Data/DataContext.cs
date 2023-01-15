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
            modelBuilder.Entity<Author>().HasMany(author => author.Books);
            modelBuilder.Entity<Book>().HasOne(book => book.Genre).WithMany(books => books.Books);
            modelBuilder.Entity<Book>().HasOne(genre => genre.Author).WithMany(books => books.Books);
            modelBuilder.Entity<Book>().HasMany(review => review.Reviews);
            modelBuilder.Entity<Genre>().HasMany(books => books.Books);
            modelBuilder.Entity<Review>().HasOne(reviwer => reviwer.Reviewer).WithMany(review => review.Reviews);
            modelBuilder.Entity<Reviewer>().HasMany(reviews => reviews.Reviews);
        }        
    }
}
