using FirstAPI_net7.Data;
using FirstAPI_net7.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI_net7.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {

        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        //get: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {

            //return await _context.Books.ToListAsync();
            return Ok( await _repository.GetAll());
        }


        //get: api/books/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
                
            var book = await _repository.GetBookById(id);  
            if (book == null) 
               return NotFound();
                
            
            return book;
        }


        //post: api/books

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {

            //_context.Books.Add(book);

            await _repository.Insert(book);

            return CreatedAtAction("GetBookById", new { id = book.Id }, book);


        }


        //put: api/books/2 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.Id)
               return BadRequest();
        
             
            var bookInDb = await _repository.GetBookById(id);

            if (bookInDb == null)
                return NotFound();

            //bookInDb.Title = book.Title;
            //bookInDb.Author = book.Author;
            //bookInDb.IsAvailable = book.IsAvailable;    

            //_context.Entry(book).State = EntityState.Modified;

            await _repository.Update(book);
            return NoContent();

        }

        //delete: api/books/2
        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {

            var bookToDel = await _repository.GetBookById(id);

            if (bookToDel == null)
                return NotFound();

           // _context.Books.Remove(bookToDel);
            await _repository.Delete(id);

            return bookToDel;

        }

    }
}
