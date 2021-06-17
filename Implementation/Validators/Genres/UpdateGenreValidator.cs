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
    public class UpdateGenreValidator : AbstractValidator<GenreDto>
    {
        public UpdateGenreValidator(Context _context)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Genre id is requeired").DependentRules(() =>
            {
                RuleFor(x => x.Id).Must(id => _context.Genres.Any(g => g.Id == id && g.DeleteAt == null))
                .WithMessage("Genre doesn't exist in database");
            });
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must((genre, n) => !_context.Genres.Any(x => x.Name == n && x.Id != genre.Id))
                .WithMessage("The name of genre already exists");
            });
        }
    }
}
