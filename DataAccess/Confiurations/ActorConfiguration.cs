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
    public class ActorConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.LastName).IsRequired();

            builder.HasMany(a => a.MovieActors)
                .WithOne(m => m.Actor)
                .HasForeignKey(m => m.ActorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
