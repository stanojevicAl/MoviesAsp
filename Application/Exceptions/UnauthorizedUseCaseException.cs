using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationUser user)
            : base($"User {user.Identity} with an id {user.Id} tried to execute {useCase.Name}.")
        {

        }
    }
}
