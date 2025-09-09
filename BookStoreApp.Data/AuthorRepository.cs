using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;

namespace BookStoreApp.Data;

internal class AuthorRepository : IAuthorRepository
{
    // simulacija baze podataka
    private static List<Author>? _data;

    public List<Author> GetAll()
    {
        return _data!;
    }

    public Author? GetById(int id)
    {
        return _data!.SingleOrDefault(x => x.Id == id);
    }

    public void Add(Author model)
    {
        _data!.Add(model);
    }

    public void Update(Author model)
    {
        var data = _data!.SingleOrDefault(x => x.Id == model.Id);
        if (data != null)
        {
            //TODO: mapirati sve propertyje
        }
    }

    public void Delete(int id)
    {
        var data = _data!.SingleOrDefault(x => x.Id == id);
        if (data != null)
        {
            _data!.Remove(data);
        }
    }
}
