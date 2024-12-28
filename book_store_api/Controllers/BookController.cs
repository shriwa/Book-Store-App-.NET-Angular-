using book_store_api.Data;
using book_store_api.Models;
using book_store_api.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace book_store_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDBContext dBContext;

        public BookController(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBookById(Guid id)
        {
            var book = dBContext.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }


        [HttpGet]
        public IActionResult GetBooks()
        {
            var allBooks = dBContext.Books.ToList();
            return Ok(allBooks);
        }


        [HttpPost]
        public IActionResult AddBook(AddBooksDTO addBooksDTO)
        {
            var bookEntity = new Book()
            {
                Title = addBooksDTO.Title,
                Author = addBooksDTO.Author,
                ISBN = addBooksDTO.ISBN,
                PublicationDate = addBooksDTO.PublicationDate
            };

            dBContext.Books.Add(bookEntity);
            dBContext.SaveChanges();

            return Ok(bookEntity);
        }



        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult UpdateBook(Guid id, [FromBody] UpdateBookDTO updateBookDTO)
        {
            // Retrieve the book from the database
            var book = dBContext.Books.FirstOrDefault(x => x.Id == id);

            // Check if the book exists
            if (book == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            // Update the book properties with DTO data if present
            if (!string.IsNullOrWhiteSpace(updateBookDTO.Title))
            {
                book.Title = updateBookDTO.Title;
            }
            if (!string.IsNullOrWhiteSpace(updateBookDTO.Author))
            {
                book.Author = updateBookDTO.Author;
            }
            if (!string.IsNullOrWhiteSpace(updateBookDTO.ISBN))
            {
                book.ISBN = updateBookDTO.ISBN;
            }
            if (updateBookDTO.PublicationDate.HasValue)
            {
                book.PublicationDate = updateBookDTO.PublicationDate.Value;
            }

            // Save changes to the database
            dBContext.SaveChanges();

            // Return the updated book details
            return Ok(new
            {
                Message = "Book updated successfully",
                Book = new
                {
                    book.Id,
                    book.Title,
                    book.Author,
                    book.ISBN,
                    book.PublicationDate
                }
            });
        }

        [HttpDelete]
        [Route("{id:Guid}")]

        public IActionResult DeleteBook(Guid id)
        {
            var book = dBContext.Books.Find(id);

            if (book == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            dBContext.Books.Remove(book);
            dBContext.SaveChanges();

            return Ok(new { Message = "Book deleted successfully" });
        }
    }
}
