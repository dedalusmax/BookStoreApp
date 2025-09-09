using BookStoreApp.Domain.Interfaces;

namespace BookStoreApp.Data;

public abstract class BaseRepository<T> : IRepository<T> where T : class, IEntity
{
    protected static List<T>? _data;

    public List<T> GetAll()
    {
        return _data!;
    }

    public T? GetById(int id)
    {
        return _data!.SingleOrDefault(x => x.Id == id);
    }

    public void Add(T model)
    {
        _data!.Add(model);
    }

    public abstract void Update(T model);

    public void Delete(int id)
    {
        var data = _data!.SingleOrDefault(x => x.Id == id);
        if (data != null)
        {
            _data!.Remove(data);
        }
    }
}
