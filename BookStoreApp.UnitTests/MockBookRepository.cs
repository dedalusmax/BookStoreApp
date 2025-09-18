using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;

namespace BookStoreApp.Data;

public class MockBookRepository : IBookRepository
{
    // simulacija baze podataka
    private static List<Book>? _books;

    public MockBookRepository()
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

    public List<Book> GetAllBooks()
    {
        return _books!;
    }

    public Book? GetBookById(int id)
    {
        return _books!.SingleOrDefault(x => x.Id == id);
    }

    public void AddBook(Book book)
    {
        _books!.Add(book);
    }

    public void UpdateBook(Book book)
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

    public void DeleteBook(int id)
    {
        var data = _books!.SingleOrDefault(x => x.Id == id);
        if (data != null)
        {
            _books!.Remove(data);
        }
    }
}
