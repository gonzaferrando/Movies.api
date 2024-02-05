using Movies.Api.Contracts.Movie;
using Movies.Api.Data.Models;
using Riok.Mapperly.Abstractions;

namespace Movies.Api
{
    [Mapper]
    public partial class Mappers
    {
        public partial MovieResponse MovieToMovieResponse(Movie movie);

        [MapperIgnoreTarget(nameof(Movie.Actors))]
        public partial IEnumerable<MovieResponse> MoviesToMovieResponseList(IEnumerable<Movie> movies);
        public partial Movie UpdateMovieRequestToMovie(UpdateMovieRequest movie);
        public partial Movie CreateMovieRequestToMovie(CreateMovieRequest movie);
    }
}
