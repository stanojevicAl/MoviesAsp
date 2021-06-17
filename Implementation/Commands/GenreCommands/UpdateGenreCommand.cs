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
    public class UpdateGenreCommand : IUpdateGenreCommand
    {
        private readonly Context _context;
        private readonly UpdateGenreValidator _validator;

        public UpdateGenreCommand(Context context, UpdateGenreValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 6;

        public string Name => "Update genre";

        public void Execute(GenreDto request)
        {
            _validator.ValidateAndThrow(request);

            var genre = _context.Genres.FirstOrDefault(x => x.Id == request.Id);

            genre.Name = request.Name;

            _context.SaveChanges();
        }
    }
}
