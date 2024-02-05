using Movies.Api.Contracts.Movie;
using Movies.Api.Data.Models;

namespace Movies.Api.Repositories.Interfaces
{
    public interface IMoviesRepository : IRepository<Movie>
    {
        Task<List<SearchMovieResponse>> Search(string? title);
    }
}
