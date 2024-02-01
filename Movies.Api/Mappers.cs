using Movies.Api.Data.Models;
using Riok.Mapperly.Abstractions;

namespace Movies.Api
{
    [Mapper]
    public partial class Mappers
    {
        public partial Contracts.Movie.MovieResponse MovieToMovieResponse(Movie movie);
        public partial IEnumerable<Contracts.Movie.MovieResponse> MoviesToMovieResponseList(IEnumerable<Movie> movies);
        public partial Movie UpdateMovieRequestToMovie(Contracts.Movie.UpdateMovieRequest movie);
        public partial Movie CreateMovieRequestToMovie(Contracts.Movie.CreateMovieRequest movie);
    }
}
