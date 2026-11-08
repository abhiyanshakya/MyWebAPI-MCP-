using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data;

//FirstAPIContext has been inherented from the Microsoft.EntityFrameworkCore.DbContext class
public class FirstAPIContext : DbContext
{
    //constructor
    public FirstAPIContext(DbContextOptions<FirstAPIContext> options) : base(options)
    {
            
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Dune",
                Author = "Frank Herbert",
                YearPublished = 1965
            },
            new Book
            {
                Id = 2,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                YearPublished = 1960
            },
            new Book
            {
                Id = 3,
                Title = "1984",
                Author = "George Orwell",
                YearPublished = 1949
            },
            new Book
            {
                Id = 4,
                Title = "The Hobbit",
                Author = "J. R. R. Tolkien",
                YearPublished = 1937
            },
            new Book
            {
                Id = 5,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                YearPublished = 1925
            }
        );
    }
    public DbSet<Book> Books { get; set; }
}