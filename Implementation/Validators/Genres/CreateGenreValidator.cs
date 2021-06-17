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
    public class CreateGenreValidator : AbstractValidator<GenreDto>
    {
        public CreateGenreValidator(Context _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(g => !_context.Genres.Any(x => x.Name == g))
                .WithMessage("The name of genre already exists");
            });
        }
    }
}
