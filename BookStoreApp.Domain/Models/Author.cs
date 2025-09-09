using System.ComponentModel;

namespace BookStoreApp.Domain.Models;

public class Author
{
    public int Id { get; set; }

    [DisplayName("Autor knjige")]
    public string Name { get; set; }
}
