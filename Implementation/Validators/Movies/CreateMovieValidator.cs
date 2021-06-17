using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateMovieValidator : MovieValidator
    {
        public CreateMovieValidator(Context _context) : base(_context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name).Must(n => !_context.Movies.Any(m => m.Name == n && m.DeleteAt == null))
                .WithMessage("Movie with that name already exists database");
            });
            RuleFor(x => x.Link).NotEmpty().WithMessage("Link is required").DependentRules(() =>
            {
                RuleFor(x => x.Link).Must(l => !_context.Movies.Any(m => m.Link == l && m.DeleteAt == null))
                .WithMessage("Movie with that link already exists database");
            });
            RuleFor(x => x.Image).NotEmpty().WithMessage("Image is required");
            RuleFor(x => x.CoverImage).NotEmpty().WithMessage("Cover image is required");
        }
    }
}
