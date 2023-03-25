using FirstAPI_net7.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI_net7.Data
{
    public class BooksDb: DbContext
    {

        public BooksDb(DbContextOptions<BooksDb> options) : base(options) 
        { 
        
        }

        public DbSet<Book> Books => Set<Book>();


    }
}
