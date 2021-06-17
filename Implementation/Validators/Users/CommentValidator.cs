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
    public class CommentValidator : AbstractValidator<CommentMovieDto>
    {
        public CommentValidator(Context _context)
        {
            RuleFor(x => x.IdMovie).NotEmpty().WithMessage("Movie is required").DependentRules(() =>
            {
                RuleFor(x => x.IdMovie).Must(x => _context.Movies.Any(y => y.Id == x && y.DeleteAt == null))
                .WithMessage("Movie doesn't exist in database");
            });
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Comment is required");
        }
    }
}
