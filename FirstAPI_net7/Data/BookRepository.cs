using Dapper;
using FirstAPI_net7.Models;
using System.Data;

namespace FirstAPI_net7.Data
{
    public class BookRepository : IBookRepository
    {

        private readonly IDbConnection _dbConnection;
        
        public BookRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task Delete(int id)
        {
            var sql = @"delet from Books WHERE Id = @Id";

            await _dbConnection.ExecuteAsync(sql, new
            {
                Id = id,

            });
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var sql = @"select Id
                              ,Titulo      
                              ,Author
                              ,IsAvailable
                        from Books ";

            return await _dbConnection.QueryAsync<Book>(sql, new { });
        }

        public async Task<Book> GetBookById(int id)
        {
            var sql = @"select Id
                              ,Titulo      
                              ,Author
                              ,IsAvailable
                        from Books 
                        where Id = @Id";

            return await _dbConnection.QueryFirstOrDefaultAsync<Book>(sql, new { Id = id });
        }

        public async Task Insert(Book book)
        {

            var sql = @"INSERT INTO Books(Id, Titulo, Author,IsAvailable)
                                    values(@Id,@Title;@Author,@IsAvailable)
                        ";

            await _dbConnection.ExecuteAsync(sql, new
            {
                book.Id,
                book.Title,
                book.Author,
                book.IsAvailable
            });
        }

        public async Task Update(Book book)
        {
            var sql = @"UPDATE Books 
                                    SET Titulo = @Title,
                                        Author = @Author,
                                        IsAvailable = @IsAvailable
                                    WHERE Id = @Id
                                    ";

            await _dbConnection.ExecuteAsync(sql, new
            {
                book.Id,
                book.Title,
                book.Author,
                book.IsAvailable
            });
        }
    }
}

