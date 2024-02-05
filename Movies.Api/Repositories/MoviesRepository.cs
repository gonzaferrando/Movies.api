using Microsoft.EntityFrameworkCore;
using Movies.Api.Contracts.Movie;
using Movies.Api.Data;
using Movies.Api.Data.EFCore;
using Movies.Api.Data.Models;
using Movies.Api.Repositories.Interfaces;

namespace Movies.Api.Repositories
{
    public class MoviesRepository : EFRepository<Movie, MoviesDbContext>, IMoviesRepository
    {
        private readonly IMoviesDbContext _context;
        public MoviesRepository(MoviesDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<SearchMovieResponse>> Search(string? title)
        {
            return await _context.Movies
                                    .Include(m => m.Actors)
                                    .Where(m => string.IsNullOrEmpty(title) || (!string.IsNullOrEmpty(title) && m.Title.ToUpperInvariant().Trim() == title.ToUpperInvariant().Trim()))
                                    .Select(m => new SearchMovieResponse
                                    {
                                        Id = m.Id,
                                        Title = m.Title,
                                        Actors = m.Actors.Select(a => new SearchMovieActorResponse
                                        {
                                            Id = a.Id,
                                            FirstName = a.FirstName,
                                            LastName = a.LastName,
                                        })
                                    })
                                    .ToListAsync();
        }
    }
}
