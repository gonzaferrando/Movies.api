using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Movie>> GetMovieActors(string title)
        {
            return await _context.Movies
                    .Include(m => m.MovieActor)
                    .Where(m => m.Title.ToUpperInvariant().Trim() == title.ToUpperInvariant().Trim())
                    .ToListAsync();
        }
    }
}
