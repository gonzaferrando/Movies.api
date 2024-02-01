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

            builder.HasOne(d => d.Movie)
                .WithMany(p => p.MovieActor)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieActor_Movie");

            builder.HasOne(d => d.Actor)
                .WithMany(p => p.MovieActor)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieActor_Actor");
        }
    }
}
