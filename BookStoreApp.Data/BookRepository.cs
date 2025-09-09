using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;

namespace BookStoreApp.Data;

public class BookRepository : BaseRepository<Book>, IBookRepository
{
    public BookRepository()
    {
        _data ??=
            [
                new() { Id = 1, Name = "Lord of the Rings", DateTimeBorrowed = DateTime.Today.AddDays(-3), IsBorrowed = true },
                new() { Id = 2, Name = "Hobbit", DateTimeBorrowed = DateTime.Today.AddDays(-1) },
                new() { Id = 3, Name = "Silmarillion", DateTimeBorrowed = DateTime.Today.AddDays(-2) }
            ];
    }

    public override void Update(Book model)
    {
        var data = _data!.SingleOrDefault(x => x.Id == model.Id);
        if (data != null)
        {
            data.Name = model.Name;
            data.Author = model.Author;
            data.IsBorrowed = model.IsBorrowed;
            data.DateTimeBorrowed = model.DateTimeBorrowed;
        }
    }

    #region Custom methods

    public void Borrow(Book book)
    {
        book.IsBorrowed = true; 
    }

    public List<Book> GetAvailableBooks()
    {
        return _data!.Where(x => !x.IsBorrowed).ToList();
    }

    public List<Book> GetTopSellingBooks()
    {
        return _data!.Take(3).ToList();
    }

    #endregion
}
