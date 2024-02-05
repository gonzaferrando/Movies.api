using Movies.Api.Data.Models;

namespace Movies.Api.Data
{
    public static class MovieDBInitializer
    {
        public static void Seed(MoviesDbContext context)
        {
            var movieId1 = Guid.NewGuid();
            var movieId2 = Guid.NewGuid();
            var movieId3 = Guid.NewGuid();

            var movies = new List<Movie>()
            {
                new()
                {
                    Id = movieId1,
                    Title = "Matrix",
                    Genre = (int)MovieGenres.Action,
                    Description = "This is the description for Matrix movie.",
                    ReleaseDate = new DateTime(1990, 1, 1),
                },
                new()
                {
                    Id = movieId2,
                    Title = "The Mask",
                    Genre = (int)MovieGenres.Comedy,
                    Description = "This is the description for The Mask movie.",
                    ReleaseDate = new DateTime(1995, 2, 2),
                },
                new()
                {
                    Id = movieId3,
                    Title = "Titanic",
                    Genre = (int)MovieGenres.Drama,
                    Description = "This is the description for Titanic movie.",
                    ReleaseDate = new DateTime(1996, 3, 3),
                }
            };

            context.Movies.AddRange(movies);

            var actorId1 = Guid.NewGuid();
            var actorId2 = Guid.NewGuid();
            var actorId3 = Guid.NewGuid();
            var actorId4 = Guid.NewGuid();
            var actorId5 = Guid.NewGuid();
            var actorId6 = Guid.NewGuid();
            var actors = new List<Actor>()
            {
                new() { Id = actorId1, FirstName = "Leonardo", LastName = "DiCaprio"},
                new() { Id = actorId2, FirstName = "Kate", LastName = "Winslet"},
                new() { Id = actorId3, FirstName = "Keanu", LastName = "Reeves"},
                new() { Id = actorId4, FirstName = "Carrie-Anne", LastName = "Moss"},
                new() { Id = actorId5, FirstName = "Jim", LastName = "Carrey"},
                new() { Id = actorId6, FirstName = "Cameron", LastName = "Diaz"},
            };

            context.Actors.AddRange(actors);

            var movieActors = new List<MovieActor>()
            {
                new() { ActorId = actorId1, MovieId = movieId3 },
                new() { ActorId = actorId2, MovieId = movieId3 },
                new() { ActorId = actorId3, MovieId = movieId1 },
                new() { ActorId = actorId4, MovieId = movieId1 },
                new() { ActorId = actorId5, MovieId = movieId2 },
                new() { ActorId = actorId6, MovieId = movieId2 }
            };

            context.MovieActors.AddRange(movieActors);
            context.SaveChanges();


        }
    }
}
