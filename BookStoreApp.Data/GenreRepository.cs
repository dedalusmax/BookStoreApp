using BookStoreApp.Domain.Interfaces;
using BookStoreApp.Domain.Models;

namespace BookStoreApp.Data
{
    internal class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository()
        {
            _data ??=
                [
                    new() { Id = 1, Name = "Science Fiction" },
                    new() { Id = 2, Name = "Fantasy" },
                    new() { Id = 3, Name = "Mystery" },
                    new() { Id = 4, Name = "Romance" },
                    new() { Id = 5, Name = "Horror" }
                ];
        }

        public override void Update(Genre model)
        {
            var data = _data!.SingleOrDefault(x => x.Id == model.Id);
            if (data != null)
            {
                data.Name = model.Name;
            }
        }
    }
}
