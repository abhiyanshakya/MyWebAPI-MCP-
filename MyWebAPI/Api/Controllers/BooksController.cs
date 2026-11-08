using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        /*
        *The reason we are static because this way the list will be created once when the controller is first instantiated.
        */
        // static private List<Book> books = new List<Book>
        // {
        //     new Book
        //     {
        //         Id = 1,
        //         Title = "Dune",
        //         Author = "Frank Herbert",
        //         YearPublished = 1965
        //     },
        //     new Book
        //     {
        //         Id = 2,
        //         Title = "To Kill a Mockingbird",
        //         Author = "Harper Lee",
        //         YearPublished = 1960
        //     },
        //     new Book
        //     {
        //         Id = 3,
        //         Title = "1984",
        //         Author = "George Orwell",
        //         YearPublished = 1949
        //     },
        //     new Book
        //     {
        //         Id = 4,
        //         Title = "The Hobbit",
        //         Author = "J. R. R. Tolkien",
        //         YearPublished = 1937
        //     },
        //     new Book
        //     {
        //         Id = 5,
        //         Title = "The Great Gatsby",
        //         Author = "F. Scott Fitzgerald",
        //         YearPublished = 1925
        //     }
        // };

        private readonly FirstAPIContext _context;

        public BooksController(FirstAPIContext context)
        {
            _context = context;
        }

        [HttpGet] //GET all book list
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("id")] //Get specific book
        public async Task<ActionResult<Book>>GetBooksById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null)
                return NotFound();
            else
            {
             return Ok(book);   
            }
        }

        [HttpPost] //Post specific book
        public async Task<ActionResult<Book>>AddBook(Book newbook)
        {
            if(newbook == null)
            {
                return BadRequest();
            }
            else
            {
                _context.Books.Add(newbook);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetBooksById), new {id = newbook.Id}, newbook);
            }
        }

        [HttpPut("id")]
        //Not returning any object we are just returning status code therefore we use IActionResult Action Method.
        public async Task<IActionResult> UpdateBook(int id, Book UpdatedBook)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                book.Id = UpdatedBook.Id;
                book.Title = UpdatedBook.Title;
                book.Author = UpdatedBook.Author;
                book.YearPublished = UpdatedBook.YearPublished;

                await _context.SaveChangesAsync();

                return NoContent();
            }
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
