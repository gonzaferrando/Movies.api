using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Api.Data.Models;

namespace Movies.Api.Data.Configurations
{
    public class MovieConfigurations : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(s => s.Description)
                .IsRequired()
                .HasMaxLength(300);

            builder.Property(s => s.Genre)
                .IsRequired();

            builder.Property(s => s.ReleaseDate)
                .IsRequired();
        }
    }
}
