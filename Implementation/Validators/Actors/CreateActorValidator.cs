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
    public class CreateActorValidator : ActorValidator
    {
        public CreateActorValidator(Context _context) : base(_context)
        {
            RuleFor(x => x.LastName)
                .Must((actor, lastname) => !_context.Actors.Any(a => a.Name == actor.Name && a.LastName == lastname && a.DeleteAt == null))
                .WithMessage("Actor already exists");
        }
    }
}
