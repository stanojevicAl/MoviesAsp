using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using Implementation.Validators.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class UpdateActorValidator : ActorValidator
    {
        public UpdateActorValidator(Context _context) : base(_context)
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Actor id is requeired").DependentRules(() =>
            {
                RuleFor(x => x.Id).Must(id => _context.Actors.Any(a => a.Id == id && a.DeleteAt == null))
                .WithMessage("Actor doesn't exist in database");
            });
            RuleFor(x => x.LastName)
                .Must((actor, lastname)
                => !_context.Actors.Any(a => a.Name == actor.Name && a.LastName == lastname && a.Id != actor.Id && a.DeleteAt == null))
                .WithMessage("Actor already exists");
        }
    }
}
