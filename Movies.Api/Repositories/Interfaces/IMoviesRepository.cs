using Movies.Api.Data.Models;

namespace Movies.Api.Repositories.Interfaces
{
    public interface IMoviesRepository : IRepository<Movie>
    {
        Task<List<Movie>> GetMovieActors(string title);
    }
}
