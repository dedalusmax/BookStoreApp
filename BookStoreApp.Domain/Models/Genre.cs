using BookStoreApp.Domain.Interfaces;

namespace BookStoreApp.Domain.Models;

public class Genre : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }
}
