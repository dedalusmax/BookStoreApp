using BookStoreApp.Domain.Models;

namespace BookStoreApp.Domain.Interfaces;

public interface IBookRepository
{
    List<Book> GetAllBooks();

    Book? GetBookById(int id);

    void AddBook(Book book);

    void UpdateBook(Book book);

    void DeleteBook(int id);
}
