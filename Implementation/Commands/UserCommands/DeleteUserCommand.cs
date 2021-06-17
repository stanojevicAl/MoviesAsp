using Application.DataTransfer;
using Application.Exceptions;
using Application.Interfaces.Commands;
using DataAccess;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands
{
    public class DeleteUserCommand : IDeleteCommand
    {
        private readonly Context _context;

        public DeleteUserCommand(Context context)
        {
            _context = context;
        }

        public int Id => 13;

        public string Name => "Delete user";

        public void Execute(int request)
        {
            var user = _context.Users.Find(request);

            user.DeleteAt = DateTime.Now;
            user.Active = false;

            _context.SaveChanges();
        }
    }
}
