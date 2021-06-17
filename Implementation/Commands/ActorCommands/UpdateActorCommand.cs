using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces.Commands;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class UpdateActorCommand : ICreateActorCommand
    {
        private readonly Context _context;
        private readonly UpdateActorValidator _validator;

        public UpdateActorCommand(Context context, UpdateActorValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Update actor";

        public void Execute(ActorDto request)
        {
            _validator.ValidateAndThrow(request);

            var actor = _context.Actors.FirstOrDefault(x => x.Id == request.Id);

            actor.Name = request.Name;
            actor.LastName = request.LastName;

            _context.SaveChanges();

        }
    }
}
