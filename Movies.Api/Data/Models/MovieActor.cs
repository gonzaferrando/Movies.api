namespace Movies.Api.Data.Models
{
    public class MovieActor
    {
        public Guid MovieId { get; set; }
        public Guid ActorId { get; set; }

        public virtual Movie Movie { get; set; } = new Movie();
        public virtual Actor Actor { get; set; } = new Actor();
    }
}
