using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces.Commands;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using Implementation.Profiles;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Implementation.Commands
{
    public class UpdateMovieCommand : IUpdateMovieCommand
    {
        private readonly Context _context;
        private readonly UpdateMovieValidator _validator;

        public UpdateMovieCommand(Context context, UpdateMovieValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 9;

        public string Name => "Update move";

        public void Execute(MovieDto request)
        {
            _validator.ValidateAndThrow(request);

            var movie = _context.Movies.Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
                .Include(x => x.MovieActors)
                .ThenInclude(x => x.Actor)
                .Include(x => x.MovieRatings).FirstOrDefault(x => x.Id == request.Id);
            
            if (request.Image != null)
            {
                var guid = Guid.NewGuid();

                var extension = Path.GetExtension(request.Image.FileName);

                var newImageName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newImageName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    request.Image.CopyTo(fileStream);
                }
                movie.Image = newImageName;
            }
            if(request.CoverImage != null)
            {
                var guid = Guid.NewGuid();

                var extensionCover = Path.GetExtension(request.CoverImage.FileName);

                var newCoverImageName = guid + extensionCover;

                var pathCover = Path.Combine("wwwroot", "images", newCoverImageName);

                using (var fileStream = new FileStream(pathCover, FileMode.Create))
                {
                    request.CoverImage.CopyTo(fileStream);
                }

                movie.CoverImage = newCoverImageName;
            }

            movie.Name = request.Name;
            movie.Description = request.Description;
            movie.Duration = request.Duration;
            movie.Year = request.Year;
            movie.Link = request.Link;

            foreach (var actorFromReques in request.Actors)
            {
                var act = new MovieActor
                {
                    ActorId = actorFromReques.ActorId,
                    MovieId = movie.Id
                };

                if (!movie.MovieActors.Any(x => x.ActorId == actorFromReques.ActorId))
                {
                    movie.MovieActors.Add(new MovieActor
                    {
                        ActorId = actorFromReques.ActorId
                    });
                }
            }

            foreach (var genreFromReques in request.Genres)
            {
                if (!movie.MovieGenres.Any(x => x.GenreId == genreFromReques.GenreId))
                {
                    movie.MovieGenres.Add(new MovieGenre
                    {
                        GenreId = genreFromReques.GenreId
                    });
                }
            }

            _context.SaveChanges();
        }
    }
}
