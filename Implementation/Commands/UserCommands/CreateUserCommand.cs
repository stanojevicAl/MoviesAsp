using Application.DataTransfer;
using Application.Interfaces.Commands;
using Application.Interfaces.Email;
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
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly Context _context;
        private readonly CreateUserValidator _validator;
        private readonly IEmailSender _sender;
        public CreateUserCommand(Context context, CreateUserValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 12;

        public string Name => "User registration";

        public void Execute(UserDto request)
        {
            _validator.ValidateAndThrow(request);

            var roleId = _context.Roles.FirstOrDefault(x => x.Name == "User");
            var activationCode = request.Email.GetHashCode().ToString() + DateTime.Now.ToFileTime();

            var user = new User
            {
                Name = request.Name,
                LastName = request.LastName,
                Username = request.Username,
                Email = request.Email,
                Password = request.Password,
                ActivationCode = activationCode,
                RoleId = roleId.Id
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "Successfull registration. Please confirm your registration with the following activation code so you can log in. Code: "+activationCode ,
                SendTo = request.Email,
                Subject = "Registration"
            });
        }
    }
}
