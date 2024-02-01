using Microsoft.EntityFrameworkCore;
using Movies.Api.Data.Models;

namespace Movies.Api.Data
{
    public class MoviesDbContext : DbContext, IMoviesDbContext
    {
        public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(MoviesDbContext).Assembly);
        }
    }
}
