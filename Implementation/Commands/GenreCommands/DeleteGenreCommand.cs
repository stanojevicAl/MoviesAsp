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
    public class DeleteGenreCommand : IDeleteCommand
    {
        private readonly Context _context;

        public DeleteGenreCommand(Context context)
        {
            _context = context;
        }

        public int Id => 5;

        public string Name => "Delete genre";

        public void Execute(int request)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Id == request && x.DeleteAt == null);

            if (genre == null)
            {
                throw new EntityNotFoundException(typeof(Genre));
            }

            genre.DeleteAt = DateTime.Now;
            genre.Active = false;

            _context.SaveChanges();
        }
    }
}
