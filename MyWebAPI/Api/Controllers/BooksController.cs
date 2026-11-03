using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //The reason we are static because this way the list will be created once when the controller is first instantiated.
        static private List<Book> books = new List<Book>
        {
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
        };

        [HttpGet] //GET all book list
        public ActionResult<List<Book>> GetBooks()
        {
            return Ok(books);
        }

        [HttpGet("id")] //Get specific book
        public ActionResult<Book>GetBooksById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<Book>AddBook(Book newbook)
        {
            if(newbook == null)
            {
                return BadRequest();
            }
            else
            {
                books.Add(newbook);

                return CreatedAtAction(nameof(GetBooksById), new {id = newbook.Id}, newbook);
            }
        }

        [HttpPut("id")]
        //Not returning any object we are just returning status code
        public IActionResult UpdateBook(int id, Book UpdatedBook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

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

                return NoContent();
            }
        }

        [HttpDelete("id")]
        public IActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                books.Remove(book);

                return NoContent();
            }
        }
    }
}
