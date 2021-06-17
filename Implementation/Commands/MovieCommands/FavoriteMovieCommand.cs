using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Commands.MovieCommands;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.MovieCommands
{
    public class FavoriteMovieCommand : IFavoriteMovieCommand
    {
        private readonly Context _context;
        private readonly IApplicationUser _user;

        public FavoriteMovieCommand(Context context, IApplicationUser user)
        {
            _context = context;
            _user = user;
        }

        public int Id => 20;

        public string Name => "Facorite movie";

        public void Execute(FavoriteMovieDto request)
        {

            var favorite = new UserFavorite
            {
                UserId = _user.Id,
                MovieId = request.MovieId
            };

            _context.UserFavorites.Add(favorite);
            _context.SaveChanges();
        }
    }
}
