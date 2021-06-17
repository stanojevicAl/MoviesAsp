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
    public class VerificationValidator : AbstractValidator<VerificationDto>
    {
        public VerificationValidator(Context _context)
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").DependentRules(() =>
            {
                RuleFor(x => x.Email).Must((user, email) => _context.Users.Any(x => x.Email == email && x.ActivationCode == user.ActivatinCode))
                .WithMessage("Email and activation code don't match");
            });

            RuleFor(x => x.ActivatinCode).NotEmpty().WithMessage("Activation code is required");
        }
    }
}
