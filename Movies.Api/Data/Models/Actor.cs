using Movies.Api.Data.Abstractions;

namespace Movies.Api.Data.Models
{
    public class Actor : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<Movie> Movies { get; set; }

        public Actor()
        {
            Movies = new HashSet<Movie>();
        }

    }
}
