using FirstAPI_net7.Data;
using FirstAPI_net7.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            return await _context.Books.ToListAsync();
        }


        //get: api/books/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
                
            var book = await _context.Books.FindAsync(id);  
            if (book == null) 
               return NotFound();
                
            
            return Ok(book);
        }


        //post: api/books

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {

            _context.Books.Add(book);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBookById", new { id = book.Id }, book);


        }


        //put: api/books/2 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();


            }
             
            var bookInDb = await _context.Books.FindAsync(id);

            if (bookInDb == null)
            {
                return NotFound();

            }

            _context.Entry(book).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();

        }

        //delete: api/books/2
        [HttpDelete("{id]")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {

            var bookToDel = await _context.Books.FindAsync(id);

            if (bookToDel == null)
                return NotFound();

            _context.Books.Remove(bookToDel);
            await _context.SaveChangesAsync();

            return Ok(bookToDel);

        }

    }
}
