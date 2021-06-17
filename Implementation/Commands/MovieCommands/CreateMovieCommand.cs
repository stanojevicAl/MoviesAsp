using Application.DataTransfer;
using Application.Interfaces.Commands;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class CreateMovieCommand : ICreateMovieCommand
    {
        private readonly Context _context;
        private readonly CreateMovieValidator _validator;
        private readonly IMapper _mapper;
        public CreateMovieCommand(Context context, CreateMovieValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 7;

        public string Name => "Create new movie";

        public void Execute(MovieDto request)
        {
            _validator.ValidateAndThrow(request);

            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(request.Image.FileName);

            var newImageName = guid + extension;

            var extensionCover = Path.GetExtension(request.CoverImage.FileName);

            var newCoverImageName = guid + extensionCover;

            var movie = new Movie
            {
                Name = request.Name,
                Description = request.Description,
                Duration = request.Duration,
                Year = request.Year,
                Link = request.Link,
                Image = newImageName,
                CoverImage = newCoverImageName
            };

            var path = Path.Combine("wwwroot", "images", newImageName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                request.Image.CopyTo(fileStream);
            }

            var pathCover = Path.Combine("wwwroot", "images", newCoverImageName);
            using (var fileStream = new FileStream(pathCover, FileMode.Create))
            {
                request.CoverImage.CopyTo(fileStream);
            }

            foreach (var genre in request.Genres)
            {
                movie.MovieGenres.Add(new MovieGenre
                {
                    GenreId = genre.GenreId
                });
            }

            foreach (var actor in request.Actors)
            {
                movie.MovieActors.Add(new MovieActor
                {
                    ActorId = actor.ActorId
                });
            }

            _context.Movies.Add(movie);

            _context.SaveChanges();
        }
    }
}
