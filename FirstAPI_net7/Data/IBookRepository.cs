using FirstAPI_net7.Models;

namespace FirstAPI_net7.Data
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAll();
        Task<Book> GetBookById(int id);
        
        Task Insert(Book book);
        Task Update(Book book);
        Task Delete(int id);


    }
}
