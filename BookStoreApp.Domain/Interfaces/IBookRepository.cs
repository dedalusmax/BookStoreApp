using BookStoreApp.Domain.Models;

namespace BookStoreApp.Domain.Interfaces;

public interface IBookRepository : IRepository<Book>
{
    // add custom methods here if needed

    void Borrow(Book book);

    List<Book> GetAvailableBooks();

    List<Book> GetTopSellingBooks();
}
