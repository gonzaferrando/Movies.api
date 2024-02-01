using Movies.Api.Data.Abstractions;

namespace Movies.Api.Data.Models
{
    public class Movie : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Genre { get; set; }
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<MovieActor> MovieActor { get; set; }

        public virtual ICollection<MovieRating> MovieRating { get; set; }

        public Movie()
        {
            MovieActor = new HashSet<MovieActor>();
            MovieRating = new HashSet<MovieRating>();
        }
    }
}
