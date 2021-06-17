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
    public class DeleteMovieCommand : IDeleteCommand
    {
        private readonly Context _context;

        public DeleteMovieCommand(Context context)
        {
            _context = context;
        }

        public int Id => 8;

        public string Name => "Delete movie";

        public void Execute(int request)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == request && x.DeleteAt == null);

            if (movie == null)
            {
                throw new EntityNotFoundException(typeof(Movie));
            }

            movie.DeleteAt = DateTime.Now;
            movie.Active = false;

            _context.SaveChanges();
        }
    }
}
