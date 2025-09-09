using System.ComponentModel;

namespace BookStoreApp.Domain.Models;

public class Book
{
    public int Id { get; set; }

    [DisplayName("Naziv knjige")]
    public string Name { get; set; }

    [DisplayName("Posuđena?")]
    public bool IsBorrowed { get; set; }

    [DisplayName("Datum posudbe")]
    public DateTime? DateTimeBorrowed { get; set; }

    [DisplayName("Autor")]
    public Author Author { get; set; }
}
