using Movies.Api.Data;
using Movies.Api.Data.Models;

namespace Movies.Api.Contracts.Movie
{
    public class MovieResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public MovieGenres Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<Actor> Actors { get; set; } = Enumerable.Empty<Actor>();
    }
}
