using Application.DataTransfer;
using Application.DataTransfer.Users;
using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.Queries;
using Application.Searches;
using AutoMapper;
using DataAccess;
using Domain.Entities;
using Implementation.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries
{
    public class GetUserQuery : IGetUserQuery
    {
        private readonly IApplicationUser _user;
        private readonly Context _context;
        private readonly IMapper _mapper;

        public GetUserQuery(Context context, IMapper mapper, IApplicationUser user)
        {
            _context = context;
            _mapper = mapper;
            _user = user;
        }

        public int Id => 18;

        public string Name => "Get user";

        public PagesResponse<ReadUserDto> Execute(CommonSearch search)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == _user.Id && x.DeleteAt == null);
            if(user == null)
            {
                throw new EntityNotFoundException(typeof(User));
            }
            if (user.RoleId == 2)
            {
                var users = _context.Users.Where(x => x.Id == _user.Id && x.DeleteAt == null).AsQueryable();
                return users.Paged<ReadUserDto, User>(search, _mapper);
            }
            else
            {
                var query = _context.Users.Where(x => x.DeleteAt == null).AsQueryable();
                if (search.Id.HasValue)
                {
                    query = query.Where(x => x.Id == search.Id);
                }
                if (!string.IsNullOrEmpty(search.Name) || !string.IsNullOrWhiteSpace(search.Name))
                {
                    var name = search.Name.ToLower();
                    query = query.Where(x => x.Name.ToLower().Contains(name) ||
                                             x.LastName.ToLower().Contains(name) ||
                                             x.Username.ToLower().Contains(name));
                }


                var users = query.Paged<ReadUserDto, User>(search, _mapper);
                if (users.Items.Count() == 0)
                {
                    throw new EntityNotFoundException(typeof(User));
                }
                return users;
            }
        }
    }
}
