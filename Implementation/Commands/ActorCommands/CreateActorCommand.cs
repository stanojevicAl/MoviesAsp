using Application.DataTransfer;
using Application.Interfaces.Commands;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using FluentValidation;
using Implementation.Validators;
using Implementation.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class CreateActorCommand : ICreateActorCommand
    {
        private readonly Context _context;
        private readonly CreateActorValidator _validator;
        private readonly IMapper _mapper;

        public CreateActorCommand(Context context, CreateActorValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 1;

        public string Name => "Create new actor";

        public void Execute(ActorDto request)
        {
            _validator.ValidateAndThrow(request);

            _context.Actors.Add(_mapper.Map<Actor>(request));

            _context.SaveChanges();
        }
    }
}
