using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces;
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
    public class UpdateUserCommand : IUpdateUserCommand
    {
        private readonly Context _context;
        private readonly UpdateUserValidator _validator;
        private readonly IApplicationUser _user;
        public UpdateUserCommand(Context context, UpdateUserValidator validator, IApplicationUser user)
        {
            _context = context;
            _validator = validator;
            _user = user;
        }

        public int Id => 14;

        public string Name => "Update user";

        public void Execute(UpdateUserDto request)
        {
            request.Id = _user.Id;
            _validator.ValidateAndThrow(request);

            var user = _context.Users.FirstOrDefault(x => x.Id == _user.Id && x.DeleteAt == null);

            if (user == null)
            {
                throw new EntityNotFoundException(typeof(User));
            }

            user.Name = request.Name;
            user.LastName = request.LastName;
            user.Username = request.UserName;
            user.Password = request.Password;


            _context.SaveChanges();

        }
    }
}
