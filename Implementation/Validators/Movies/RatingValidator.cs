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
    public class RatingValidator : AbstractValidator<RatingMovieDto>
    {
        public RatingValidator(Context _context)
        {
            RuleFor(x => x.MoviedId).NotEmpty().WithMessage("Movie is required").DependentRules(() =>
            {
                RuleFor(x => x.MoviedId).Must(x => _context.Movies.Any(y => y.Id == x && y.DeleteAt == null))
                .WithMessage("Movie doesn't exist in database");
            });
            RuleFor(x => x.Pating).NotEmpty().WithMessage("Rating is required").DependentRules(() =>
            {
                RuleFor(x => x.Pating).InclusiveBetween(1, 10)
                .WithMessage("Rating must be between 1 and 10");
            });
        }
    }
}
