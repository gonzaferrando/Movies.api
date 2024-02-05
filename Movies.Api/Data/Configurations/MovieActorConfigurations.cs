using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Api.Data.Models;

namespace Movies.Api.Data.Configurations
{
    public class MovieActorConfigurations : IEntityTypeConfiguration<MovieActor>
    {
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(e => new { e.MovieId, e.ActorId });
        }
    }
}
