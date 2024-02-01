using Microsoft.EntityFrameworkCore;
using Movies.Api.Data.Models;

namespace Movies.Api.Data
{
    public interface IMoviesDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Actor> Actors { get; set; }
        DbSet<MovieActor> MovieActors { get; set; }
        DbSet<MovieRating> MovieRatings { get; set; }
    }
}
