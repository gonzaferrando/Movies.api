namespace Movies.Api.Data.Models
{
    public class MovieRating
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public int Score { get; set; }
        public virtual Movie Movie { get; set; } = new Movie();
    }
}
