using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Api.Data.Models;

namespace Movies.Api.Data.Configurations
{
    public class MovieRatingConfigurations : IEntityTypeConfiguration<MovieRating>
    {
        public void Configure(EntityTypeBuilder<MovieRating> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(s => s.Score)
                .IsRequired();

            builder.HasOne(d => d.Movie)
                .WithMany(p => p.MovieRating)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieRating_Movie");
        }
    }
}
