namespace BookStoreApp.Domain.Interfaces;

public interface IRepository<T> where T : class, IEntity
{
    List<T> GetAll();

    T? GetById(int id);

    void Add(T model);

    void Update(T model);

    void Delete(int id);
}
