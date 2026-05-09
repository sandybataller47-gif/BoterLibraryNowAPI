using BoterLibraryNowAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BoterLibraryNowAPI.Controller
{
    [Route("api/v1/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Trust ",
                Author = "Hernan Diaz ",
                Genre = " Fiction ",
                Available = true,
                PublisheYear = 22
            },
            new Book
            {
                Id = 2,
                Title = "Trust in Me ",
                Author = "Jennifer L. Armentrout ",
                Genre = "Romance ",
                Available = true,
                PublisheYear = 2013
            }
        };
        [HttpGet]

        public IActionResult GetAII()
        {
            return Ok(new
            {
                status = "success",
                data = books,
                message = "Books Retrived."


            });

        }
        [HttpGet("(id)")]

        public IActionResult GetById(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Books Not found."


                });
            return Ok(new
            {
                status = "success",
                data = books,
                message = "Books Retrived."


            });


        }
        [HttpPost]
        public IActionResult Create([FromBody] Book newbooK)
        {
            newbooK.Id = books.Count + 1;
            books.Add(newbooK);
            return CreatedAtAction(nameof(GetById),
                new { id = newbooK.Id },
                new { status = "success",
                    data = newbooK,
                    message = "Book Created."
                });
        }
        [HttpPut]
        public IActionResult Update(int id, [FromBody] Book updatebook)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not found."

                });
            book.Title = updatebook.Title;
            book.Author = updatebook.Author;
            book.Genre = updatebook.Genre;
            book.Available = updatebook.Available;
            book.PublisheYear = updatebook.PublisheYear;

            return Ok(new
            {
                status = "success",
                data = book,
                message = "Book updated."


            });

        }
        [HttpDelete("")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            if (book == null)
                return NotFound(new
                {
                    status = "error",
                    data = (object?)null,
                    message = "Book not found."

                });
            books.Remove(book);
            return Ok(new
            {
                status = "success",
                data = book,
                message = "Book updated."


            });

        }
    }
}