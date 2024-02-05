namespace Movies.Api.Contracts.Movie
{
    public class SearchMovieActorResponse
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }

    public class SearchMovieResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public IEnumerable<SearchMovieActorResponse> Actors { get; set; } = Enumerable.Empty<SearchMovieActorResponse>();
    }
}
