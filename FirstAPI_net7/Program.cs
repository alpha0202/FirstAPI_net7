using FirstAPI_net7.Data;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FirstAPI_net7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            var connString = builder.Configuration.GetConnectionString("conexionPredeterminada");
            builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(connString));


            builder.Services.AddScoped<IBookRepository, BookRepository>(); //inyectando nuestas propias dependencias 


            //builder.Services.AddDbContext<BooksDb>(opt => opt.UseInMemoryDatabase("BookList")); //conexión db en memoria

            

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}