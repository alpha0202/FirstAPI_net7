using FirstAPI_net7.Data;
using FirstAPI_net7.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI_net7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController: Controller
    {

        private readonly BooksDb _context;

        public BooksController(BooksDb context)
        {
            _context = context;
        }

        //get: api/books

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {

            return;
        }


        //get: api/books/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
                

        }


        //post: api/books

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {

        }


        //put: api/books/2 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {

        }


        //delete: api/books/2
        [HttpDelete("{id]")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {

        }

    }
}
