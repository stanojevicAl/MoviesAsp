using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator(Context _context)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("First name is required").DependentRules(() =>
            {
                RuleFor(x => x.Name)
                .MinimumLength(3)
                .MaximumLength(30)
                .Matches("^[A-Z][a-z]")
                .WithMessage("First name is not in correct format");
            });

            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required").DependentRules(() =>
            {
                RuleFor(x => x.LastName)
                .MinimumLength(3)
                .MaximumLength(30)
                .Matches("^[A-Z][a-z]")
                .WithMessage("Last name is not in correct format");
            });

            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is required").DependentRules(() =>
            {
                RuleFor(x => x.UserName)
                .MinimumLength(6)
                .MaximumLength(30)
                .Matches("[a-z]")
                .Matches("[1-9]")
                .WithMessage("Username is not in correct format");
            }).DependentRules(() =>
            {
                RuleFor(x => x.UserName)
                .Must((user, un) => !_context.Users.Any(u => u.Username == un && u.Id != user.Id && u.DeleteAt == null))
               .WithMessage("User with that username already exists in database.");
            });

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").DependentRules(() =>
            {
                RuleFor(x => x.Password)
                .MinimumLength(8)
                .MaximumLength(30)
                .Matches("[a-z]")
                .Matches("[1-9]")
                .WithMessage("Password is not in correct format");
            });
            

        }
    }
}
