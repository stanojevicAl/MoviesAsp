using Application.Exceptions;
using Application.Interfaces.Commands;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class DeleteActorCommand : IDeleteCommand
    {
        private readonly Context _context;

        public DeleteActorCommand(Context context)
        {
            _context = context;
        }

        public int Id => 2;

        public string Name => "Delete Actor";

        public void Execute(int request)
        {
            var actor = _context.Actors.FirstOrDefault(x => x.Id == request && x.DeleteAt == null);

            if (actor == null)
            {
                throw new EntityNotFoundException(typeof(Actor));
            }

            actor.DeleteAt = DateTime.Now;
            actor.Active = false;

            _context.SaveChanges();
        }
    }
}
