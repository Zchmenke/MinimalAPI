using Microsoft.EntityFrameworkCore;
using MinimalAPI.Models;
using static Azure.Core.HttpHeader;

namespace MinimalAPI.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(
                new Book()
                {
                    BookId = 1,
                    Title = "Lord Of The Rings",
                    Author = "Jrr. Tolkien",
                    Available = true,
                    ReleaseYear = 1954,
                    Genre = "Fantasy"

                },
                new Book()
                {
                    BookId = 2,
                    Title = "In Search Of Lost Time",
                    Author = "Marcel Proust",
                    Available = true,
                    ReleaseYear = 1913,
                    Genre = "Fiction"

                },
                 new Book()
                 {
                     BookId = 3,
                     Title = "Fingerprints Of the Gods",
                     Author = "Graham Hancock",
                     Available = false,
                     ReleaseYear = 1995,
                     Genre = "Pseudoarcheology"
                 },
                 new Book()
                 {
                     BookId = 4,
                     Title = "The God Delusion",
                     Author = "Richard Dawkins",
                     Available = true,
                     ReleaseYear = 1995,
                     Genre = "Fact"
                 },
                 new Book()
                 {
                     BookId = 5,
                     Title = "The Holy Bible",
                     Author = "Unknown / King James Bible",
                     Available = true,
                     ReleaseYear = 0000,
                     Genre = "Religious Text"
                 }

            );
        }
    }
}
