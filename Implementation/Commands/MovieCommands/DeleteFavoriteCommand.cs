using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.MovieCommands
{
    public class DeleteFavoriteCommand : IDeleteCommand
    {
        private readonly Context _context;
        private readonly IApplicationUser _user;

        public DeleteFavoriteCommand(Context context, IApplicationUser user)
        {
            _context = context;
            _user = user;
        }
        public int Id => 21;

        public string Name => "Delete favorite movie";

        public void Execute(int request)
        {
            var favorite = _context.UserFavorites.FirstOrDefault(x => x.MovieId == request && x.UserId == _user.Id);
            if(favorite == null)
            {
                new EntityNotFoundException(typeof(UserFavorite));
            }

            _context.UserFavorites.Remove(favorite);
            _context.SaveChanges();
        }
    }
}
