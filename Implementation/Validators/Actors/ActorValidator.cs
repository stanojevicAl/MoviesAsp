using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Actors
{
    public class ActorValidator : AbstractValidator<ActorDto>
    {
        public ActorValidator(Context _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required.").DependentRules(() =>
            {
                RuleFor(x => x.Name)
                .MinimumLength(3)
                .MaximumLength(30)
                .Matches("^[A-Z][a-z]")
                .WithMessage("First name is not in correct format");
            });
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Lastname is required.").DependentRules(() =>
            {
                RuleFor(x => x.LastName)
                .MinimumLength(3)
                .MaximumLength(30)
                .Matches("^[A-Z][a-z]")
                .WithMessage("Last name is not in correct format");
            });
        }
    }
}
