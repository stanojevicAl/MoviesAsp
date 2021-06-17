using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class MovieValidator : AbstractValidator<MovieDto>
    {
        public MovieValidator(Context _context)
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(x => x.Duration).NotEmpty().WithMessage("Durarion is required").DependentRules(() =>
            {
                RuleFor(x => x.Duration).InclusiveBetween(50, 350)
                .WithMessage("Duration must be between 50 and 350 minutes");
            });
            RuleFor(x => x.Year).NotEmpty().WithMessage("Year is required").DependentRules(() =>
            {
                RuleFor(x => x.Year).InclusiveBetween(1965, DateTime.Now.Year)
                .WithMessage("Year must be between 1965 and current year");
            });
            RuleFor(x => x.Genres).NotEmpty().WithMessage("Genre is required").DependentRules(() =>
            {
                RuleFor(x => x.Genres).Must(g => g.Select(x => x.GenreId).Distinct().Count() == g.Count())
                .WithMessage("Dupplicate genres are not allowed");
            }).DependentRules(() =>
            {
                RuleForEach(x => x.Genres).SetValidator(new CreateMovieGenreValidator(_context));
            });
            RuleFor(x => x.Actors).NotEmpty().WithMessage("Actor is required").DependentRules(() =>
            {
                RuleFor(x => x.Actors).Must(a => a.Select(x => x.ActorId).Distinct().Count() == a.Count())
                .WithMessage("Dupplicate actors are not allowed");
            }).DependentRules(() =>
            {
                RuleForEach(x => x.Actors).SetValidator(new CreateMovieActorValidator(_context));
            });
        }
    }

    public class CreateMovieGenreValidator : AbstractValidator<MovieGereDto>
    {
        public CreateMovieGenreValidator(Context _context)
        {
            RuleFor(x => x.GenreId).NotEmpty().WithMessage("Genre is required").DependentRules(() =>
            {
                RuleFor(x => x.GenreId)
                .Must(g => _context.Genres.Any(x => x.Id == g && x.Active == true && x.DeleteAt == null))
                .WithMessage("Genre does't exists in database.");
            });
        }
    }

    public class CreateMovieActorValidator : AbstractValidator<MovieActorDto>
    {
        public CreateMovieActorValidator(Context _context)
        {
            RuleFor(x => x.ActorId).NotEmpty().WithMessage("Actor is required").DependentRules(() =>
            {
                RuleFor(x => x.ActorId)
                .Must(a => _context.Actors.Any(x => x.Id == a && x.Active == true && x.DeleteAt == null))
                .WithMessage("Actor does't exists in database.");
            });
        }
    }
}
