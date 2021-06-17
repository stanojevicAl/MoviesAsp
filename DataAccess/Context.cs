using DataAccess.Confiurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-HSGD5SI\SQLEXPRESS;Initial Catalog=MovieAsp;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());

            modelBuilder.Entity<MovieActor>().HasKey(x => new { x.ActorId, x.MovieId });
            modelBuilder.Entity<MovieGenre>().HasKey(x => new { x.GenreId, x.MovieId });
            modelBuilder.Entity<MovieRating>().HasKey(x => new { x.UserId, x.MovieId });
            modelBuilder.Entity<UserFavorite>().HasKey(x => new { x.UserId, x.MovieId });

        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.Active = true;
                            e.CreatedAt = DateTime.Now;
                            e.DeleteAt = null;
                            e.UpdateAt = null;
                            break;
                        case EntityState.Modified:
                            e.UpdateAt = DateTime.Now;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }
        public DbSet<MovieComment> MovieComments { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<UserFavorite> UserFavorites { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }

    }
}
