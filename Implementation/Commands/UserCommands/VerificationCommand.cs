using Application.DataTransfer;
using Application.Interfaces.Commands.UserCommands;
using DataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.UserCommands
{
    public class VerificationCommand : IVerificationCommand
    {
        private readonly Context _context;
        private readonly VerificationValidator _validator;

        public VerificationCommand(Context context, VerificationValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 24;

        public string Name => "Confirm registration ";

        public void Execute(VerificationDto request)
        {
            _validator.ValidateAndThrow(request);
            var user = _context.Users.FirstOrDefault(x => x.Email == request.Email && x.ActivationCode == request.ActivatinCode);

            user.Verification = true;
            _context.SaveChanges();
        }
    }
}
