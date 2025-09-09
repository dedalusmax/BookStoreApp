using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;

namespace BookStoreApp.Data;

public class BookRepository : IBookRepository
{
    // simulacija baze podataka
    private static List<Book>? _books;

    public BookRepository()
    {
        if (_books == null)
        {
            _books =
            [
                new() { Id = 1, Name = "Lord of the Rings", DateTimeBorrowed = DateTime.Today.AddDays(-3), IsBorrowed = true },
                    new() { Id = 2, Name = "Hobbit", DateTimeBorrowed = DateTime.Today.AddDays(-1) },
                    new() { Id = 3, Name = "Silmarillion", DateTimeBorrowed = DateTime.Today.AddDays(-2) }
            ];
        }
    }

    public List<Book> GetAll()
    {
        return _books!;
    }

    public Book? GetById(int id)
    {
        return _books!.SingleOrDefault(x => x.Id == id);
    }

    public void Add(Book book)
    {
        _books!.Add(book);
    }

    public void Update(Book book)
    {
        var data = _books!.SingleOrDefault(x => x.Id == book.Id);
        if (data != null)
        {
            data.Name = book.Name;
            data.Author = book.Author;
            data.IsBorrowed = book.IsBorrowed;
            data.DateTimeBorrowed = book.DateTimeBorrowed;
        }
    }

    public void Delete(int id)
    {
        var data = _books!.SingleOrDefault(x => x.Id == id);
        if (data != null)
        {
            _books!.Remove(data);
        }
    }

    #region Custom methods

    public void Borrow(Book book)
    {
        throw new NotImplementedException();
    }

    public List<Book> GetAvailableBooks()
    {
        throw new NotImplementedException();
    }

    public List<Book> GetTopSellingBooks()
    {
        throw new NotImplementedException();
    }

    #endregion
}
