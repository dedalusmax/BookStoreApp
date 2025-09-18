using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace BookStoreApp.Data;

public class BookRepository : IBookRepository
{
    private readonly SqlConnection _connection;

    public BookRepository(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        _connection = new SqlConnection(connectionString);
    }

    public void AddBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void DeleteBook(int id)
    {
        throw new NotImplementedException();
    }

    public List<Book> GetAllBooks()
    {
        return [];
    }

    public Book? GetBookById(int id)
    {
        var book = new Book();

        _connection.Open();

        using var command = new SqlCommand("SELECT * FROM Book WHERE BookId = @book_id;", _connection);
        command.Parameters.AddWithValue("@book_id", id);

        using var reader = command.ExecuteReader();
        reader.Read();

        book.Id = (int)reader["BookId"];
        book.Name = (string)reader["Title"];

        _connection.Close();    

        return book;
    }

    public void UpdateBook(Book book)
    {
        throw new NotImplementedException();
    }
}
