﻿using Application.DataTransfer;
using DataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class CreateUserValidator : AbstractValidator<UserDto>
    {
        public CreateUserValidator(Context _context) 
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

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").DependentRules(() =>
            {
                RuleFor(x => x.Email).EmailAddress().WithMessage("Email is not in correct format");
            }).DependentRules(() =>
            {
                RuleFor(x => x.Email).Must(x => !_context.Users.Any(u => u.Email == x && u.DeleteAt == null))
                .WithMessage("User with that email already exists in database.");
            });

            RuleFor(x => x.Username).NotEmpty().WithMessage("Username is required").DependentRules(() =>
            {
                RuleFor(x => x.Username)
                .MinimumLength(6)
                .MaximumLength(30)
                .Matches("[a-z]")
                .Matches("[1-9]")
                .WithMessage("Username is not in correct format");
            }).DependentRules(() =>
            {
                RuleFor(x => x.Username).Must(x => !_context.Users.Any(u => u.Username == x && u.DeleteAt == null))
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