using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Confiurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasIndex(x => x.Link).IsUnique();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Duration).IsRequired();
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Link).IsRequired();
            builder.Property(x => x.Image).IsRequired();
            builder.Property(x => x.CoverImage).IsRequired();

            builder.HasMany(m => m.MovieGenres)
                .WithOne(g => g.Movie)
                .HasForeignKey(g => g.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.MovieActors)
                .WithOne(a => a.Movie)
                .HasForeignKey(a => a.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.MovieComments)
                .WithOne(c => c.Movie)
                .HasForeignKey(c => c.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.MovieRatings)
                .WithOne(r => r.Movie)
                .HasForeignKey(r => r.MovieId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(m => m.UserFavorites)
                .WithOne(f => f.Movie)
                .HasForeignKey(f => f.MovieId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
