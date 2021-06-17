using Application.DataTransfer;
using Application.Interfaces.Commands;
using AutoMapper;
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
    public class CreateGenreCommand : ICreateGenreCommand
    {
        private readonly Context _context;
        private readonly CreateGenreValidator _validator;
        private readonly IMapper _mapper;

        public CreateGenreCommand(Context context, CreateGenreValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Create genre";

        public void Execute(GenreDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Genres.Add(_mapper.Map<Genre>(request));

            _context.SaveChanges();
        }
    }
}
