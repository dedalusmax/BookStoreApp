using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;

namespace BookStoreApp.Data;

public class AuthorRepository : BaseRepository<Author>, IAuthorRepository
{
    public AuthorRepository()
    {
        _data ??=
            [
                new() { Id = 1, Name = "J.K. Rowling" },
                new() { Id = 2, Name = "George R.R. Martin" },
                new() { Id = 3, Name = "J.R.R. Tolkien" }
            ];
    }

    public override void Update(Author model)
    {
        var data = _data!.SingleOrDefault(x => x.Id == model.Id);
        if (data != null)
        {
            data.Name = model.Name;
        }
    }
}
